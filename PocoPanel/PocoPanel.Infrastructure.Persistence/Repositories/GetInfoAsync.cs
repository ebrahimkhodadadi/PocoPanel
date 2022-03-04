using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocoPanel.Application.Interfaces;
using PocoPanel.Domain.Entities;
using PocoPanel.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PocoPanel.Infrastructure.Persistence.Repositories
{
    public class GetInfoAsync : IGetInfo
    {
        #region Properties
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructor
        public GetInfoAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        [ResponseCache(Duration = 360)]
        public async Task<IEnumerable<tblCountry>> GetAllCountryAsync()
        {
            return await _dbContext.tblCountry.ToListAsync();
        }

        [ResponseCache(Duration = 60)]
        public async Task<tblPriceKind> GetPriceKindByCountryId(int countryId)
        {
            return await _dbContext.tblPriceKind.FirstOrDefaultAsync(tblPriceKind => tblPriceKind.tblCountryId == countryId);
        }
    }
}
