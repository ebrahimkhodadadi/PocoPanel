using PocoPanel.Application.DTOs.Factors;
using PocoPanel.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocoPanel.Application.Interfaces.Repositories
{
    public interface IOrderDetailRepositoryAsync : IGenericRepositoryAsync<tblOrderDetail>
    {
        public Task<IEnumerable<OrderDetailViewModel>> GetOrderDetailViewModelAsync(string UserId, string currency);
        public Task<OrderDetailViewModel> GetOrderDetailViewModelByIdAsync(string UserID, int id, string currency);
    }
}