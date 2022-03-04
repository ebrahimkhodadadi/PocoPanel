using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocoPanel.Application.DTOs.Providers;
using PocoPanel.Application.Exceptions;
using PocoPanel.Application.Interfaces;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using PocoPanel.Domain.Entities;
using PocoPanel.Infrastructure.Persistence.Contexts;
using PocoPanel.Infrastructure.Persistence.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPanel.Infrastructure.Persistence.Repositories
{
    public class ProviderRepositoryAsync : IProviderRepositoryAsync
    {
        #region Properties
        private readonly ApplicationDbContext _dbContext;
        private IProviderAsync _IProvicerAsync;
        private readonly IConvert _IConvert;
        #endregion

        #region Constructor
        public ProviderRepositoryAsync(ApplicationDbContext dbContext, IConvert iConvert)
        {
            _dbContext = dbContext;
            _IConvert = iConvert;
        }
        #endregion

        [ResponseCache(Duration = 360)]
        public async Task<IEnumerable<ProvidersViewModel>> GetAllProvidersViewModelAsync()
        {
            var tblProviders = await _dbContext.tblProvider.ToListAsync();

            foreach (var provider in tblProviders)
            {
                var credit = await ProviderHelper.GetProvider(provider).GetCredit();
                provider.ProviderCredit = _IConvert.RoundNumber(credit.balance);
            }

            return tblProviders.Select(providers => new ProvidersViewModel()
            {
                Id = providers.Id,
                Url = providers.Url,
                Code = providers.Code,
                DocumentAddress = providers.DocumentAddress,
                Credit = providers.ProviderCredit
            });
        }

        public async Task<Response<bool>> ApplyAllProductsFromProviderAsync(int Id)
        {
            var tblprovider = await _dbContext.tblProvider.FindAsync(Id);
            if (tblprovider == null)
                throw new ApiException("سایت پذیرنده انتخاب شده یافت نشد.");

            //دریافت محصولات
            _IProvicerAsync = ProviderHelper.GetProvider(tblprovider);
            var providerProducts = await _IProvicerAsync.GetProducts();

            //آیا محصول از قبل ثبت شده است یا خیر
            var savedProducts = await _dbContext.tblProduct
                .IgnoreQueryFilters()
                .Where(products => products.tblProviderId == tblprovider.Id)
                .ToListAsync();

            var listDistinctProducts = providerProducts
                .AsEnumerable().Where(provider =>
                !savedProducts.Select(saved => saved.ProviderProductID).Contains(provider.service))
                .Select(provider => new tblProduct()
                { 
                    Name = provider.name,
                    Description = provider.desc,
                    Max = provider.max,
                    Min = provider.min,
                    Title = provider.category,
                    Price = Convert.ToDecimal(provider.rate),
                    tblProductKindId = 25, //Unkown
                    tblProviderId = tblprovider.Id,
                    ProviderProductID = provider.service
                })
                .ToList();

            if(listDistinctProducts?.Count() <= 0)
                return new Response<bool>(true, $"محصول جدیدی جهت ثبت موجود نمی باشد.");

            //ذخیره
            await _dbContext.tblProduct.AddRangeAsync(listDistinctProducts);
            await _dbContext.SaveChangesAsync();

            return new Response<bool>(true, $"تعداد {listDistinctProducts?.Count()} محصول جدید به سایت افزوده شد.");
        }
    }
}
