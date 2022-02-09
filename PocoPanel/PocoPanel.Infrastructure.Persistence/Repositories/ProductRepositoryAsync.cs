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

namespace PocoPanel.Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<tblProduct>, IProductRepositoryAsync
    {
        private readonly DbSet<tblProduct> _products;
        private readonly ApplicationDbContext _dbContext;
        public readonly IConvert _IConvert;

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
                Quantity = product.Quantity,
                MainCategory = product.tblProductKind?.tblProductKinds?.Name,
                Category = product?.tblProductKind.Name
            };
        }

        public async Task<IEnumerable<GetProductViewModel>> GetProductViewModelByIdAsync(string currency)
        {
            var products = await _dbContext.tblProduct
                .Include(product => product.tblProductKind)
                .ThenInclude(product => product.tblProductKinds.tblProductKinds)
                .Include(product => product.tblProductPriceKind)
                .ThenInclude(product => product.tblPriceKind)
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
                Quantity = product.Quantity,
                MainCategory = product.tblProductKind?.tblProductKinds?.Name,
                Category = product?.tblProductKind.Name
            });
        }
    }
}
