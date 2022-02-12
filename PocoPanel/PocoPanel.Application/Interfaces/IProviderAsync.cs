using PocoPanel.Application.DTOs.Factors;
using PocoPanel.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PocoPanel.Application.Interfaces.Repositories
{
    public interface IProviderAsync
    {
        public Task<GetOrderResponse> CreateOrder(OrderViewModel OrderViewModel);
        public Task<GetOrderViewModel> GetOrderStatus(int orderId);
        public Task<List<ProviderProductViewModel>> GetProducts();
        public Task<ProviderProductViewModel> GetProductById(int ProductId);
        public Task<CreditResponseViewModel> GetCredit();
    }
}
