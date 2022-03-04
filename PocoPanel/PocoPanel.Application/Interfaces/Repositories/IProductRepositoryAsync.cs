using PocoPanel.Application.DTOs.Products;
using PocoPanel.Application.Features.Products.Queries.GetAllProducts;
using PocoPanel.Application.Wrappers;
using PocoPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PocoPanel.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<tblProduct>
    {
        public Task<bool> IsExistProductKindId(int tblProductKindId);
        public Task<bool> IsExistProviderId(int tblProviderId);
        public Task<GetProductViewModel> GetProductViewModelByIdAsync(int id, string currency);
        public Task<GetProductDetailViewModel> GetProductDetailViewModelByIdAsync(int id); 
        public Task<IEnumerable<GetProductViewModel>> GetProductViewModelAsync(string currency);
        public Task<IEnumerable<GetAllProductsByProductKindViewModel>> GetAllProductsByProductKindIdAsync(int productKindId);
        public Task<PagedResponse<IEnumerable<GetAllProductsViewModel>>> GetAllProductsPagedReponseAsync(GetAllProductsParameter getAllProductsParameter, bool? isDelete);
        public Task<tblProduct> GetProductByIdAsync(int id);
        public Task<ListProductPriceViewModel> GetProductPricesById(int id);
        public Task<bool> EditeProductPriceAsync(ListProductPriceViewModel listProductPrice);
    }
}
