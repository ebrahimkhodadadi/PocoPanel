using System.Reflection;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Domain.Entities;
using PocoPanel.Infrastructure.Persistence.Contexts;
using PocoPanel.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoPanel.Application.DTOs.Products;
using PocoPanel.Application.Interfaces;
using PocoPanel.Application.Features.Products.Queries.GetAllProducts;
using PocoPanel.Application.Wrappers;
using System.Web.Mvc;
using PocoPanel.Infrastructure.Shared.Enums;
using PocoPanel.Application.Exceptions;

namespace PocoPanel.Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<tblProduct>, IProductRepositoryAsync
    {
        private readonly DbSet<tblProduct> _products;
        private readonly ApplicationDbContext _dbContext;
        private readonly IConvert _IConvert;

        public ProductRepositoryAsync(ApplicationDbContext dbContext, IConvert iConvert) : base(dbContext)
        {
            _products = dbContext.Set<tblProduct>();
            _dbContext = dbContext;
            _IConvert = iConvert;
        }

        public async Task<bool> IsExistProductKindId(int tblProductKindId)
        {
            return await _dbContext.tblProductKind.AnyAsync(tblProductKind => tblProductKind.Id == tblProductKindId && tblProductKind.ParentID != null);
        }

        public async Task<bool> IsExistProviderId(int tblProviderId)
        {
            return await _dbContext.tblProvider.AnyAsync(tblProvider => tblProvider.Id == tblProviderId);
        }

        public async Task<GetProductViewModel> GetProductViewModelByIdAsync(int id, string currency)
        {
            var product = await _dbContext.tblProduct
                .Include(product => product.tblProductKind)
                .ThenInclude(product => product.tblProductKinds.tblProductKinds)
                .Include(product => product.tblProductPriceKind)
                .ThenInclude(product => product.tblPriceKind)
                .Include(product => product.tblQuality)
                .FirstOrDefaultAsync(product => product.Id == id);

            if (product == null)
                return null;

            return new GetProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Decending = product.Decending,
                Description = product.Description,
                Price = _IConvert.RoundNumber(product.tblProductPriceKind.FirstOrDefault(product => product?.tblPriceKind?.Name == currency).Price),
                Min = product.Min,
                Max = product.Max,
                MainCategory = product.tblProductKind?.tblProductKinds?.Name,
                Category = product?.tblProductKind.Name,
                Quality = product?.tblQuality?.Name
            };
        }

        public async Task<IEnumerable<GetProductViewModel>> GetProductViewModelAsync(string currency)
        {
            var products = await _dbContext.tblProduct
                .Include(product => product.tblProductKind)
                .ThenInclude(product => product.tblProductKinds.tblProductKinds)
                .Include(product => product.tblProductPriceKind)
                .ThenInclude(product => product.tblPriceKind)
                .Include(product => product.tblQuality)
                .ToListAsync();

            if (products == null)
                return null;

            return products.Select(product => new GetProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Decending = product.Decending,
                Description = product.Description,
                Price = _IConvert.RoundNumber(product?.tblProductPriceKind.FirstOrDefault(tblproduct => tblproduct?.tblPriceKind?.Name == currency)?.Price),
                Min = product.Min,
                Max = product.Max,
                MainCategory = product.tblProductKind?.tblProductKinds?.Name,
                Category = product?.tblProductKind.Name,
                Quality = product?.tblQuality?.Name
            });
        }

        public async Task<IEnumerable<GetAllProductsByProductKindViewModel>> GetAllProductsByProductKindIdAsync(int productKindId)
        {
            var product = await _dbContext.tblProduct
                .Include(product => product.tblProductKind)
                .ThenInclude(product => product.tblProductKinds.tblProductKinds)
                .Include(product => product.tblProductPriceKind)
                .ThenInclude(product => product.tblPriceKind)
                .Where(product => productKindId == 0 || product.tblProductKindId == productKindId)
                .ToListAsync();

            return product.Select(product => new GetAllProductsByProductKindViewModel()
            {
                id = product.Id,
                price = string.Join(" ", _IConvert.RoundNumber(product?.tblProductPriceKind.FirstOrDefault(tblproduct => tblproduct?.tblPriceKind?.Name == "USD")?.Price), "USD"),
                Count = product.Max,
                Decending = product.Decending,
                Description = product.Description,
                themeColor = product.tblProductKind.tblProductKinds.Name == "Telegram" ? "blue" : product.tblProductKind.tblProductKinds.Name == "Instagram" ? "purple" : "red",
                bgImgUrl = product.tblProductKind.tblProductKinds.Name == "Telegram" ? "~/imges/TelegramBg.jpg" : product.tblProductKind.tblProductKinds.Name == "Instagram" ? "~/Images/InstagramBg.png" : "",
                Title = product.Title,
                ParentTitle = product.tblProductKind.tblProductKinds.Name,
                ChildTitle = product.tblProductKind.Name,
            });
        }

        public async Task<PagedResponse<IEnumerable<GetAllProductsViewModel>>> GetAllProductsPagedReponseAsync(GetAllProductsParameter getAllProductsParameter, bool? isDelete)
        {
            //Count
            var pageCount = await _dbContext.tblProduct.IgnoreQueryFilters().Where(product => product.IsDelete == (isDelete ?? false)).CountAsync();

            //List
            var listProducts = await _dbContext
            .tblProduct
            .IgnoreQueryFilters()
            .Where(product => product.IsDelete == (isDelete ?? false))
            .Skip((getAllProductsParameter.PageNumber - 1) * getAllProductsParameter.PageSize)
            .Take(getAllProductsParameter.PageSize)
            .AsNoTracking()
            .Include(product => product.tblProvider)
            .ToListAsync();

            //Map
            var productViewModel = listProducts.Select(product => new GetAllProductsViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Provider = product.tblProvider.Url,
                ProviderPrice = _IConvert.RoundNumber(product.Price),
                ProviderProductID = product.ProviderProductID
            });

            //return
            return new PagedResponse<IEnumerable<GetAllProductsViewModel>>(productViewModel, getAllProductsParameter.PageNumber, getAllProductsParameter.PageSize, pageCount);
        }

        public async Task<GetProductDetailViewModel> GetProductDetailViewModelByIdAsync(int id)
        {
            var product = await _dbContext.tblProduct
                .IgnoreQueryFilters()
                .Include(product => product.tblProductKind)
                .FirstOrDefaultAsync(product => product.Id == id);

            if (product == null)
                return null;

            var tblQuality = await _dbContext.tblQuality.ToListAsync();
            var tblProductKind = await _dbContext.tblProductKind.ToListAsync();

            var productDetail = new GetProductDetailViewModel()
            {
                Id = product.Id,
                IsDelete = product.IsDelete,
                Description = product.Description,
                Name = product.Name,
                Title = product.Title,
                Price = _IConvert.RoundNumber(product.Price),
                Max = product.Max,
                Min = product.Min,
                Decending = product.Decending,
                QualityId = product.tblQualityId,
                ProductKind = product.tblProductKindId,
                ProductParentKind = product.tblProductKind.ParentID,
                tblQuality = tblQuality.Select(quality => new SelectListItem() { Text = quality.Name, Value = quality.Id.ToString() }),
                tblProductKindParent = tblProductKind.Where(product => product.ParentID == null).Select(product => new SelectListItem() { Text = product.Name, Value = product.Id.ToString() }),
                tblProductKindChild = tblProductKind.Where(product => product.ParentID != null).Select(product => new ProductKindChild() { Text = product.Name, Value = product.Id, Parent = product.ParentID }),
            };

            return productDetail;
        }

        public async Task<tblProduct> GetProductByIdAsync(int id)
        {
            return await _dbContext.tblProduct.IgnoreQueryFilters().FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<ListProductPriceViewModel> GetProductPricesById(int id)
        {
            var productPrices = await _dbContext.tblProductPriceKind
                .Where(priceKind => priceKind.tblProductId == id)
                .ToListAsync();

            return new ListProductPriceViewModel()
            {
                ProductId = id,
                Rial = _IConvert.RoundNumber(productPrices.FirstOrDefault(priceKind => priceKind?.tblPriceKindId == (int)PriceKind.Rial)?.Price ?? 0),
                USD = _IConvert.RoundNumber(productPrices.FirstOrDefault(priceKind => priceKind?.tblPriceKindId == (int)PriceKind.USD)?.Price ?? 0)
            };
        }

        public async Task<bool> EditeProductPriceAsync(ListProductPriceViewModel listProductPrice)
        {
            //Get product
            var product = await _dbContext.tblProduct
                .Include(product => product.tblProductPriceKind)
                .FirstOrDefaultAsync(product => product.Id == listProductPrice.ProductId);
            if (product == null) throw new ApiException($"Product Not Found.");

            //change data
            var priceKindList = await _dbContext.tblPriceKind.ToListAsync();
            foreach (var priceKind in priceKindList)
            {
                //Fill Price
                decimal price;
                switch (priceKind.Id)
                {
                    case (int)PriceKind.Rial:
                        price = listProductPrice.Rial;
                        break;
                    case (int)PriceKind.USD:
                        price = listProductPrice.USD;
                        break;
                    default:
                        throw new ApiException($"Please Define Product Price Kind By Id {priceKind.Id}.");
                }

                //find Change Price
                //if Exist
                var productPrice = _dbContext.tblProductPriceKind.FirstOrDefault(productPrice => productPrice.tblProductId == product.Id && productPrice.tblPriceKindId == priceKind.Id);
                if (productPrice != null)
                {
                    if (price == 0)
                        _dbContext.tblProductPriceKind.Remove(productPrice);
                    else
                    {
                        productPrice.Price = price;
                        _dbContext.Entry(productPrice).State = EntityState.Modified;
                    }
                }
                //if not exist
                else if(price != 0)
                {
                    await _dbContext.tblProductPriceKind.AddAsync(new tblProductPriceKind()
                    {
                        tblPriceKindId = priceKind.Id,
                        tblProductId = product.Id,
                        Price = price
                    });
                }

                await _dbContext.SaveChangesAsync();
            }

            return true;
        }
    }
}
