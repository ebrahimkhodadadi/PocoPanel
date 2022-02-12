using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using PocoPanel.Application.DTOs.Factors;
using PocoPanel.Application.DTOs.Products;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocoPanel.Infrastructure.Persistence.Providers
{
    public class InstatellProviderAsync : IProviderAsync
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;
        private readonly string _Key;

        public InstatellProviderAsync(tblProvider tblProvider)
        {
            _url = tblProvider.Url;
            _Key = tblProvider.ProviderToken;
            _httpClient = new HttpClient();
        }

        public async Task<GetOrderResponse> CreateOrder(OrderViewModel orderModel)
        {
            var query = new Dictionary<string, string>()
            {
                ["serviceId"] = orderModel.serviceId.ToString(),
                ["link"] = orderModel.link.ToString(),
                ["quantity"] = orderModel.quantity.ToString(),
                ["key"] = _Key,
                ["action"] = "add"
            };

            var uri = QueryHelpers.AddQueryString(_url, query);
            using var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot Create Order");
            }

            var result = await response.Content.ReadAsStringAsync();
            var create = JsonConvert.DeserializeObject<GetOrderResponse>(result);

            return create;
        }

        public async Task<GetOrderViewModel> GetOrderStatus(int orderId)
        {
            var query = new Dictionary<string, string>()
            {
                ["order"] = orderId.ToString(),
                ["key"] = _Key,
                ["action"] = "status"
            };

            var uri = QueryHelpers.AddQueryString(_url, query);
            using var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot Get Order Status");
            }

            var result = await response.Content.ReadAsStringAsync();
            var orderStatus = JsonConvert.DeserializeObject<GetOrderViewModel>(result);

            return orderStatus;
        }

        public async Task<CreditResponseViewModel> GetCredit()
        {

            var query = new Dictionary<string, string>()
            {
                ["key"] = _Key,
                ["action"] = "balance"
            };

            var uri = QueryHelpers.AddQueryString(_url, query);
            using var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot Get Credit");
            }

            var result = await response.Content.ReadAsStringAsync();
            var credit = JsonConvert.DeserializeObject<CreditResponseViewModel>(result);

            return credit;
        }

        public async Task<List<ProviderProductViewModel>> GetProducts()
        {
            var query = new Dictionary<string, string>()
            {
                ["key"] = _Key,
                ["action"] = "services"
            };

            var uri = QueryHelpers.AddQueryString(_url, query);
            using var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot Get Products");
            }

            var result = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProviderProductViewModel>>(result);

            return products;
        }

        public async Task<ProviderProductViewModel> GetProductById(int ProductId)
        {
            var query = new Dictionary<string, string>()
            {
                ["key"] = _Key,
                ["action"] = "services"
            };

            var uri = QueryHelpers.AddQueryString(_url, query);
            using var response = await _httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot Get Product");
            }

            var result = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<ProviderProductViewModel>>(result);

            return product.Find(product => product.service == ProductId);
        }

    }
}
