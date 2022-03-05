using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PocoPanelWebApplication.DTOs.Account;
using PocoPanelWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        #region Properites
        private IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly WebSiteSettings _WebSiteSettings;
        #endregion

        #region Constructor
        public AuthController(IHttpClientFactory httpClientFactory, IOptions<WebSiteSettings> webSiteSettings)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = new HttpClient();
            _WebSiteSettings = webSiteSettings.Value;
        }
        #endregion

        #region Login
        [ValidateReCaptcha]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return View("../Home/SignIn", registerRequest);
            }

            var loginModel = new AuthenticationRequest()
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password
            };

            //request
            var _client = _httpClientFactory.CreateClient("APIserverURI");
            var jsonBody = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/Account/authenticate", content);

            //result of request 
            var result = await response.Content.ReadAsStringAsync();
            var authenticationResponse = JsonConvert.DeserializeObject<ApiResponse<AuthenticationModel>>(result);


            if (response.IsSuccessStatusCode)
            {
                //Roles
                var roleClaims = new List<Claim>();
                for (int i = 0; i < authenticationResponse.Data.Roles.Count; i++)
                {
                    roleClaims.Add(new Claim(ClaimTypes.Role, authenticationResponse.Data.Roles[i]));
                }

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, authenticationResponse.Data.UserName),
                    new Claim(ClaimTypes.Name, authenticationResponse.Data?.UserName),
                    new Claim("AccessToken", authenticationResponse.Data?.JWToken),
                    new Claim("PublicCode", authenticationResponse.Data?.PublicCode),
                    new Claim("PublicToken", authenticationResponse.Data?.PublicToken),
                    new Claim("UserID", authenticationResponse.Data?.Id),
                    new Claim("Email", authenticationResponse.Data?.Email),
                    new Claim("FirstName", authenticationResponse.Data?.FirstName),
                    new Claim("LastName", authenticationResponse.Data?.LastName)
                }
                .Union(roleClaims);

                if (authenticationResponse.Data.PublicToken != null)
                    claims.Union(new List<Claim>() { new Claim("PublicToken", authenticationResponse.Data?.PublicToken) });

                if (authenticationResponse.Data.PublicToken != null)
                    claims.Union(new List<Claim>() { new Claim("PublicCode", authenticationResponse.Data?.PublicCode) });

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = registerRequest.RememberMe,
                    AllowRefresh = true
                };
                await HttpContext.SignInAsync(principal, properties);

                return Redirect("~/Admin/Panel/Index");
            }
            else
            {
                ViewBag.Error = authenticationResponse.Message;
                return View("../Home/SignIn", registerRequest);
            }
        }
        #endregion

        #region Register
        [ValidateReCaptcha]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequestViewModel registerRequestViewModel)
        {
            if (!ModelState.IsValid)
                return View("../Home/Register", registerRequestViewModel);

            var content = new StringContent(JsonConvert.SerializeObject(registerRequestViewModel), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync(_WebSiteSettings.API + "/Account/register", content);

            if(!response.IsSuccessStatusCode)
            {
                var errorResult = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ApiResponse<string>>(errorResult);
                ViewBag.Error = errorModel.Message;
                return View("../Home/Register", registerRequestViewModel);
            }

            var result = await response.Content.ReadAsStringAsync();
            var authenticationModel = JsonConvert.DeserializeObject<ApiResponse<string>>(result);
            if(!authenticationModel.Succeeded)
            {
                ViewBag.Error = authenticationModel.Message;
                return View("../Home/Register", registerRequestViewModel);
            }

            ViewBag.Success = true;
            ViewBag.FullName = registerRequestViewModel.FirstName + " " + registerRequestViewModel.LastName;
            ViewBag.Email = registerRequestViewModel.Email;
            return View("../Home/SignIn");
        }
        #endregion

        #region Logout
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewBag.Logout = true;
            return Redirect("../Home/SignIn");
        }

        #endregion

        #region ForgotPassword
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (!ModelState.IsValid)
                return View("../Home/ForgotPassword", new ForgotPasswordViewModel() { Email = email });

            //Serialize
            var content = new StringContent(JsonConvert.SerializeObject(new ForgotPasswordViewModel() { Email = email }), Encoding.UTF8, "application/json");
            //Send Request
            using var response = await _httpClient.PostAsync(_WebSiteSettings.API + "/Account/forgot-password", content);

            if (!response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var responseResult = JsonConvert.DeserializeObject<ApiResponse<string>>(result);
                return BadRequest(new JsonResult(responseResult.Message));
            }

            return Redirect("~/Home/Index");
        }

        [HttpPost("ForgotPasswordPage")]
        public async Task<IActionResult> ForgotPasswordPage(string tokenCode)
        {
            return View("../Home/ResetPassword", new ResetPasswordRequest() { Token = tokenCode});
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest resetPassword)
        {
            if (!ModelState.IsValid)
                return View("../Home/ResetPassword", resetPassword);

            //Serialize
            var content = new StringContent(JsonConvert.SerializeObject(resetPassword), Encoding.UTF8, "application/json");
            //Send Request
            using var response = await _httpClient.PostAsync(_WebSiteSettings.API + "/Account/reset-password", content);

            var result = await response.Content.ReadAsStringAsync();
            var responseResult = JsonConvert.DeserializeObject<ApiResponse<string>>(result);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new JsonResult(responseResult.Message));
            }

            return new JsonResult(responseResult.Message);
        }
        #endregion
    }
}
