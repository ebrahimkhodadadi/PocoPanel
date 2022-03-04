using PocoPanel.Application.DTOs.Providers;
using PocoPanel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PocoPanel.Application.Interfaces.Repositories
{
    public interface IProviderRepositoryAsync
    {
        public Task<IEnumerable<ProvidersViewModel>> GetAllProvidersViewModelAsync();
        public Task<Response<bool>> ApplyAllProductsFromProviderAsync(int Id);
    }
}
