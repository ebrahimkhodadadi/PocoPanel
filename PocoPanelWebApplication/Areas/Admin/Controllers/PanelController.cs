using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PocoPanelWebApplication.Areas.Admin.Models;
using PocoPanelWebApplication.DTOs.Order;
using PocoPanelWebApplication.DTOs.Product;
using PocoPanelWebApplication.DTOs.Providers;
using PocoPanelWebApplication.Models;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PanelController : Controller
    {
        #region Properites
        private readonly HttpClient _httpClient;
        private readonly WebSiteSettings _WebSiteSettings;
        #endregion

        #region Constructor
        public PanelController(IOptions<WebSiteSettings> webSiteSettings)
        {
            _httpClient = new HttpClient();
            _WebSiteSettings = webSiteSettings.Value;
        }
        #endregion

        #region Sidebar Views
        public async Task<IActionResult> Index()
        {

            if (User.FindAll(ClaimTypes.Role).Any(Roles => Roles.Value == "Admin"))
                return Redirect("~/Admin/Panel/Admin");

            return Redirect("~/Admin/Panel/Profile");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Admin()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);

            using var response = await _httpClient.GetAsync(_WebSiteSettings.API + "/Factor/GetAllWaitingOrderDetails");

            if (!response.IsSuccessStatusCode)
            {
                return View(null);
            }

            var result = await response.Content.ReadAsStringAsync();
            var orderDetails = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<AcceptOrderDetailViewModel>>>(result);

            return View(orderDetails.Data);
        }

        [Authorize(Roles = "Basic")]
        public IActionResult Basic()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public async Task<IActionResult> Providers()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);

            using var response = await _httpClient.GetAsync(_WebSiteSettings.API + "/Provider/GetAllProviders");

            if (!response.IsSuccessStatusCode)
            {
                return View(null);
            }

            var result = await response.Content.ReadAsStringAsync();
            var providers = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ProvidersViewModel>>>(result);

            return View(providers.Data);
        }

        [Route("~/Admin/Panel/Products")]
        [Route("~/Panel/Products")]
        public async Task<IActionResult> Products(int PageIndex = 1)
        {
            //Authorize
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);
            //Serialize
            var content = new StringContent(JsonConvert.SerializeObject(new RequestParameterModel()
            {
                PageNumber = PageIndex,
                PageSize = 10,
                IsDeleted = false
            }), Encoding.UTF8, "application/json");
            //Send Request
            using var response = await _httpClient.PostAsync(_WebSiteSettings.API + "/Product/GetAllProductsByPage", content);

            //if succced
            if (!response.IsSuccessStatusCode)
            {
                return View(null);
            }

            //Deserialize
            var result = await response.Content.ReadAsStringAsync();
            //Cast
            var products = JsonConvert.DeserializeObject<PagedResponseModel<IEnumerable<ListProductsViewModel>>>(result);
            //Pagination
            var model = PagingList.Create<ListProductsViewModel>(products.Data.ToList(), 10, PageIndex, products.RecordCount, "", "");
            //return
            model.Action = "Products";
            return View(model);
        }

        [Route("~/Admin/Panel/DeletedProducts")]
        [Route("~/Panel/DeletedProducts")]
        public async Task<IActionResult> DeletedProducts(int PageIndex = 1)
        {
            //Authorize
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);
            //Serialize
            var content = new StringContent(JsonConvert.SerializeObject(new RequestParameterModel()
            {
                PageNumber = PageIndex,
                PageSize = 10,
                IsDeleted = true
            }), Encoding.UTF8, "application/json");
            //Send Request
            using var response = await _httpClient.PostAsync(_WebSiteSettings.API + "/Product/GetAllProductsByPage", content);

            //if succced
            if (!response.IsSuccessStatusCode)
            {
                return View(null);
            }

            //Deserialize
            var result = await response.Content.ReadAsStringAsync();
            //Cast
            var products = JsonConvert.DeserializeObject<PagedResponseModel<IEnumerable<ListProductsViewModel>>>(result);
            //Pagination
            var model = PagingList.Create<ListProductsViewModel>(products.Data.ToList(), 10, PageIndex, products.RecordCount, "", "");
            //return
            model.Action = "DeletedProducts";
            return View(model);
        }

        #endregion

        #region Accept Factor

        [HttpPost]
        public async Task<IActionResult> AcceptFactor(int id)
        {
            var query = new Dictionary<string, string>()
            {
                 { "orderDetailID", id.ToString() }
            };
            var content = new JObject();
            var uri = _WebSiteSettings.API + "/Factor/AcceptFactor";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);
            var requestUri = QueryHelpers.AddQueryString(uri, query);
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Content = new StringContent(
                content.ToString(),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();
            var acceptResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(result);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new JsonResult(acceptResponse));
            }

            return new JsonResult(acceptResponse);
        }

        #endregion

        #region Get & Edite & Active & Delete & Price Provider Products
        [HttpPost]
        public async Task<IActionResult> GetProviderProducts(int Id)
        {
            var query = new Dictionary<string, string>()
            {
                 { "Id", Id.ToString() }
            };
            var content = new JObject();
            var uri = _WebSiteSettings.API + "/Provider/ApplyAllProductsFromProvider";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);
            var requestUri = QueryHelpers.AddQueryString(uri, query);
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Content = new StringContent(
                content.ToString(),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();
            var acceptResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(result);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new JsonResult(acceptResponse));
            }

            return new JsonResult(acceptResponse);
        }

        [HttpPost]
        public async Task<IActionResult> EditeProduct(int id)
        {
            var query = new Dictionary<string, string>()
            {
                 { "id", id.ToString() }
            };
            var content = new JObject();
            var uri = _WebSiteSettings.API + "/Product/GetProductDetail";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);
            var requestUri = QueryHelpers.AddQueryString(uri, query);
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Content = new StringContent(
                content.ToString(),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();
            var productDetail = JsonConvert.DeserializeObject<ApiResponse<GetProductDetailViewModel>>(result);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new JsonResult(productDetail));
            }

            return PartialView("PartialViews/_ProductDetail", productDetail.Data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var query = new Dictionary<string, string>()
            {
                 { "id", id.ToString() }
            };
            var content = new JObject();
            var uri = _WebSiteSettings.API + "/Product/DeleteProduct";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);
            var requestUri = QueryHelpers.AddQueryString(uri, query);
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Content = new StringContent(
                content.ToString(),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.SendAsync(request);

            //if not succeed
            if (!response.IsSuccessStatusCode)
            {
                //Deserialize
                var errorResults = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(errorResults);
                var errors = new JsonResult(string.Join(Environment.NewLine, errorResponse.Errors.ToArray()));
                return BadRequest(errors);
            }

            //Deserialize
            var result = await response.Content.ReadAsStringAsync();
            //Cast
            var product = JsonConvert.DeserializeObject<ApiResponse<int>>(result);


            //return
            return new JsonResult(product);
        }

        [HttpPost]
        public async Task<IActionResult> ActiveProduct(int id)
        {
            var query = new Dictionary<string, string>()
            {
                 { "id", id.ToString() }
            };
            var content = new JObject();
            var uri = _WebSiteSettings.API + "/Product/GetProductDetail";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);
            var requestUri = QueryHelpers.AddQueryString(uri, query);
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Content = new StringContent(
                content.ToString(),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();
            var productDetail = JsonConvert.DeserializeObject<ApiResponse<GetProductDetailViewModel>>(result);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new JsonResult(productDetail));
            }

            productDetail.Data.IsDelete = false;
            return PartialView("PartialViews/_ProductDetail", productDetail.Data);
        }

        [HttpPost]
        public async Task<IActionResult> EditeProductAPI(GetProductDetailViewModel getProductDetail)
        {
            //Authorize
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);
            //Serialize
            var content = new StringContent(JsonConvert.SerializeObject(getProductDetail), Encoding.UTF8, "application/json");
            //Send Request
            using var response = await _httpClient.PostAsync(_WebSiteSettings.API + "/Product/EditeProduct", content);

            //if not succeed
            if (!response.IsSuccessStatusCode)
            {
                //Deserialize
                var errorResults = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(errorResults);
                var errors = new JsonResult(string.Join(Environment.NewLine, errorResponse.Errors.ToArray()));
                return BadRequest(errors);
            }

            //Deserialize
            var result = await response.Content.ReadAsStringAsync();
            //Cast
            var product = JsonConvert.DeserializeObject<ApiResponse<int>>(result);


            //return
            return new JsonResult(product);
        }

        [HttpPost]
        public async Task<IActionResult> PriceProductAPI(ListProductPriceViewModel getProductDetail)
        {
            //Authorize
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);
            //Serialize
            var content = new StringContent(JsonConvert.SerializeObject(getProductDetail), Encoding.UTF8, "application/json");
            //Send Request
            using var response = await _httpClient.PostAsync(_WebSiteSettings.API + "/Product/EditePriceProduct", content);

            //if not succeed
            if (!response.IsSuccessStatusCode)
            {
                //Deserialize
                var errorResults = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(errorResults);
                var errors = new JsonResult(string.Join(Environment.NewLine, errorResponse.Message));
                return BadRequest(errors);
            }

            //Deserialize
            var result = await response.Content.ReadAsStringAsync();
            //Cast
            var product = JsonConvert.DeserializeObject<ApiResponse<int>>(result);


            //return
            return new JsonResult(product);
        }

        
        [HttpPost]
        public async Task<IActionResult> PriceProduct(int id)
        {
            var query = new Dictionary<string, string>()
            {
                 { "id", id.ToString() }
            };
            var content = new JObject();
            var uri = _WebSiteSettings.API + "/Product/GetProductPrices";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirst("AccessToken")?.Value);
            var requestUri = QueryHelpers.AddQueryString(uri, query);
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Content = new StringContent(
                content.ToString(),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();
            var productDetail = JsonConvert.DeserializeObject<ApiResponse<ListProductPriceViewModel>>(result);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new JsonResult(productDetail));
            }

            return PartialView("PartialViews/_ProductPrice", productDetail.Data);
        }
        #endregion
    }
}
