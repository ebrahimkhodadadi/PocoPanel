
using Microsoft.EntityFrameworkCore;
using PocoPanel.Application.DTOs.Factors;
using PocoPanel.Application.Features.Factors.Commands.CreateFactor;
using PocoPanel.Application.Interfaces;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using PocoPanel.Domain.Entities;
using PocoPanel.Infrastructure.Persistence.Contexts;
using PocoPanel.Infrastructure.Persistence.Providers;
using PocoPanel.Infrastructure.Shared.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanel.Infrastructure.Persistence.Repositories
{
    public class FactorRepositoryAsync : IFactorRepositoryAsync
    {
        #region Properties
        private readonly ApplicationDbContext _dbContext;
        private readonly IConvert _IConvert;
        private readonly IGetUser _IGetUser;
        private IProviderAsync _IProvicerAsync;
        #endregion

        #region Constructor
        public FactorRepositoryAsync(ApplicationDbContext dbContext, IConvert iConvert, IGetUser iGetUser)
        {
            _dbContext = dbContext;
            _IConvert = iConvert;
            _IGetUser = iGetUser;
        }
        #endregion

        #region Load Provider
        public void LoadProvider(tblProvider tblProvider)
        {
            switch(tblProvider.Url)
            {
                case @"https://instatell.ir/api/v1":
                    _IProvicerAsync = new InstatellProviderAsync(tblProvider);
                    break;
            }
        }
        #endregion

        #region Create Factor
        public async Task<tblOrder> CreateFactor(CreateFactorCommand CreateFactorCommand)
        {
            var tblPriceKind = _dbContext.tblPriceKind.FirstOrDefault(productKind => productKind.Name == CreateFactorCommand.Currency);
            var tblProductPriceKind = _dbContext.tblProductPriceKind
                .FirstOrDefault(productPrice => productPrice.tblPriceKindId == tblPriceKind.Id
                                    && productPrice.tblProductId == CreateFactorCommand.ServiceId);
            //ToDo:Calcualte Discount
            // if(string.IsNullOrWhiteSpace(CreateFactorCommand.DiscountCode))
            //     CreateFactorCommand.DiscountCode = null;

            var order = new tblOrder()
            {
                CreatedBy = CreateFactorCommand.CreatedBy,
                tblPriceKindId = tblPriceKind.Id,
                TotallPrice = tblProductPriceKind?.Price ?? 0,
                //tblDiscountId = CreateFactorCommand.DiscountCode,
                tblStatusId = (int)Status.Waiting
            };

            await _dbContext.tblOrder.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            await _dbContext.tblOrderDetail.AddAsync(new tblOrderDetail()
            {
                CreatedBy = CreateFactorCommand.CreatedBy,
                Description = CreateFactorCommand.Description,
                SocialUserName = CreateFactorCommand.SocialUserName,
                Quantity = CreateFactorCommand.Quantity,
                tblProductId = CreateFactorCommand.ServiceId,
                tblOrderId = order.Id,
                TotallPrice = tblProductPriceKind?.Price ?? 0,
                tblStatusId = (int)Status.Waiting,
            });

            await _dbContext.SaveChangesAsync();

            return order;
        }
        #endregion

        #region Is exist product
        public async Task<bool> IsExistProductId(int ServiceId)
        {
            return _dbContext.tblProduct.Any(product => product.Id == ServiceId);
        }
        #endregion

        #region Provider Accept & Reject
        public async Task<Response<bool>> AcceptFactor(int orderDetailID)
        {
            //check if Order Exist
            var orderDetail = await _dbContext.tblOrderDetail
                .Include(orderDetails => orderDetails.tblProduct)
                .ThenInclude(orderDetails => orderDetails.tblProvider)
                .FirstOrDefaultAsync(orderDetails => orderDetails.Id == orderDetailID);

            if (orderDetail == null)
                return new Response<bool>(false, "سفارش مورد نظر یافت نشد.");

            if (orderDetail.tblProduct.tblProvider == null)
                return new Response<bool>(false, "سایت پذیرنده ای برای این محصول یافت نشد.");

            //Fill IProvider
            LoadProvider(orderDetail.tblProduct.tblProvider);

            //check if Provider charge is enough
            var balance = await _IProvicerAsync.GetCredit();
            if (balance.balance == 0)
                return new Response<bool>(false, "موجودی حساب شما در سایت پذیرنده صفر میباشد.");

            var product = await _IProvicerAsync.GetProductById(orderDetail.tblProduct?.ProviderProductID ?? 0);
            if (product == null)
                return new Response<bool>(false, "محصول مورد نظر در سایت پذیرنده یافت نشد.");

            if(Convert.ToDecimal(product.rate * orderDetail.Quantity) > balance.balance)
                return new Response<bool>(false, "موجودی حساب شما در سایت پذیرنده کمتر از مقدار درخواستی میباشد.");


            //ثبت سفارش و تغییر وضعیت سفارش
            var createOrderStatus = await _IProvicerAsync.CreateOrder(new OrderViewModel()
            {
                serviceId = orderDetail.tblProduct.ProviderProductID,
                link = orderDetail.SocialUserName,
                quantity = orderDetail.Quantity
            });

            if (createOrderStatus.status == "success" && createOrderStatus.order != 0)
            {
                orderDetail.tblStatusId = (int)Status.InProgress;
                await _dbContext.SaveChangesAsync();
                return new Response<bool>(true, "سفارش مورد با موفقیت تایید شد."); 
            }
            else
                return new Response<bool>(true, "ثبت سفارش از طرف سایت پذیرنده با خطا مواجه شد.");
        }

        public async Task<Response<bool>> RejectFactor(int orderDetailID, string reason)
        {
            //check if Order Exist
            var orderDetail = await _dbContext.tblOrderDetail.FindAsync(orderDetailID);
            if (orderDetail == null)
                return new Response<bool>(false, "سفارش مورد نظر یافت نشد.");

            orderDetail.tblStatusId = (int)Status.Rejected;
            await _dbContext.SaveChangesAsync();

            //ToDo: Send Customer Email

            //ToDo: تغییر وضعیت سفارش
            return new Response<bool>(true, "سفارش مورد با موفقیت حذف شد.");
        }
        #endregion
    }
}
