using Microsoft.EntityFrameworkCore;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Domain.Entities;
using PocoPanel.Infrastructure.Persistence.Contexts;
using PocoPanel.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PocoPanel.Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<tblProduct>, IProductRepositoryAsync
    {
        private readonly DbSet<tblProduct> _products;
        private readonly ApplicationDbContext _dbContext;

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<tblProduct>();
            _dbContext = dbContext;
        }

        public async Task<bool> IsExistProductKindId(int tblProductKindId)
        {
            return await _dbContext.tblProductKind.AnyAsync(tblProductKind => tblProductKind.Id == tblProductKindId && tblProductKind.ParentID != null);
        }

        public async Task<bool> IsExistProviderId(int tblProviderId)
        {
            return await _dbContext.tblProvider.AnyAsync(tblProvider => tblProvider.Id == tblProviderId);
        }
    }
}
