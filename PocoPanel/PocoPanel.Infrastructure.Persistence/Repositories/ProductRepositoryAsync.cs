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

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<tblProduct>();
        }
    }
}
