using Microsoft.EntityFrameworkCore;
using PocoPanel.Application.DTOs.Factors;
using PocoPanel.Application.Interfaces;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Domain.Entities;
using PocoPanel.Infrastructure.Persistence.Contexts;
using PocoPanel.Infrastructure.Persistence.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanel.Infrastructure.Persistence.Repositories
{
    public class OrderDetailRepositoryAsync : GenericRepositoryAsync<tblOrderDetail>, IOrderDetailRepositoryAsync
    {
        //private readonly DbSet<tblOrderDetail> _OrderDetail;
        private readonly ApplicationDbContext _dbContext;
        private readonly IConvert _IConvert;

        public OrderDetailRepositoryAsync(ApplicationDbContext dbContext, IConvert iConvert) : base(dbContext)
        {
            //_OrderDetail = dbContext.Set<tblOrderDetail>();
            _dbContext = dbContext;
            _IConvert = iConvert;
        }

        public async Task<IEnumerable<OrderDetailViewModel>> GetOrderDetailViewModelAsync(string UserId, string currency)
        {
            var orderDetails = await _dbContext.tblOrderDetail.Where(orderDetail => orderDetail.CreatedBy == UserId)
                .Include(orderDetail => orderDetail.tblOrder)
                .ThenInclude(orderDetail => orderDetail.tblPriceKind)
                .Include(orderDetail => orderDetail.tblProduct)
                .Include(orderDetail => orderDetail.tblStatus)
                .ToListAsync();

            if (orderDetails == null)
                return null;
            
            return orderDetails.Select(orderDetail => new OrderDetailViewModel()
            {
                Id = orderDetail.Id,
                OrderId = orderDetail.tblOrderId,
                Title = orderDetail.Title,
                Description = orderDetail.Description,
                TotallPrice = orderDetail.TotallPrice,
                SocialUserName = orderDetail.SocialUserName,
                Quantity = orderDetail.Quantity,
                ProductName = orderDetail?.tblProduct?.Name,
                Status = orderDetail.tblStatus.Name,
                PriceKind = orderDetail?.tblOrder?.tblPriceKind?.Name
            });
        }

        public async Task<OrderDetailViewModel> GetOrderDetailViewModelByIdAsync(string UserId, int id, string currency)
        {
            var orderDetail = await _dbContext.tblOrderDetail
                .Include(orderDetail => orderDetail.tblOrder)
                .ThenInclude(orderDetail => orderDetail.tblPriceKind)
                .Include(orderDetail => orderDetail.tblProduct)
                .Include(orderDetail => orderDetail.tblStatus)
                .FirstOrDefaultAsync(orderDetail => orderDetail.CreatedBy == UserId && orderDetail.tblOrderId == id);

            if (orderDetail == null)
                return null;

            return new OrderDetailViewModel()
            {
                Id = orderDetail.Id,
                OrderId = orderDetail.tblOrderId,
                Title = orderDetail.Title,
                Description = orderDetail.Description,
                TotallPrice = orderDetail.TotallPrice,
                SocialUserName = orderDetail.SocialUserName,
                Quantity = orderDetail.Quantity,
                ProductName = orderDetail?.tblProduct?.Name,
                Status = orderDetail.tblStatus.Name,
                PriceKind = orderDetail?.tblOrder?.tblPriceKind?.Name
            };
        }
    }
}