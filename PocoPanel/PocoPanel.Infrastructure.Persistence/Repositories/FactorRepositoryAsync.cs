
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PocoPanel.Application.DTOs.Factors;
using PocoPanel.Application.Exceptions;
using PocoPanel.Application.Features.Factors.Commands.CreateFactor;
using PocoPanel.Application.Interfaces;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using PocoPanel.Domain.Entities;
using PocoPanel.Infrastructure.Persistence.Contexts;
using PocoPanel.Infrastructure.Persistence.Providers;
using PocoPanel.Infrastructure.Shared.Enums;
using PocoPanel.WebApi.Models;
using System;
using System.Collections.Generic;
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
        private readonly IEmailService _emailService;
        private readonly WebsiteModel _Website;
        #endregion

        #region Constructor
        public FactorRepositoryAsync(ApplicationDbContext dbContext, IConvert iConvert, IGetUser iGetUser, IEmailService emailService, IOptions<WebsiteModel> website)
        {
            _dbContext = dbContext;
            _IConvert = iConvert;
            _IGetUser = iGetUser;
            _emailService = emailService;
            _Website = website.Value;
        }
        #endregion

        #region Create Factor
        public async Task<tblOrder> CreateFactor(CreateFactorCommand CreateFactorCommand)
        {
            var tblPriceKind = await _dbContext.tblPriceKind.FirstOrDefaultAsync(productKind => productKind.Name == CreateFactorCommand.Currency);
            var tblProductPriceKind = await _dbContext.tblProductPriceKind
                .FirstOrDefaultAsync(productPrice => productPrice.tblPriceKindId == tblPriceKind.Id
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
                SocialUserName = _IConvert.GetSocialUserName(CreateFactorCommand.SocialUserName),
                Quantity = CreateFactorCommand.Quantity,
                tblProductId = CreateFactorCommand.ServiceId,
                TotallPrice = _IConvert.RoundNumber(tblProductPriceKind?.Price ?? 0) ,
                tblStatusId = (int)Status.Waiting,
                tblOrderId = order.Id
            });
            await _dbContext.SaveChangesAsync();

            #region Send Email To Admin
            await _emailService.SendAsync(new Application.DTOs.Email.EmailRequest()
            {
                From = "infoEmail@pocopanel.ir",
                To = _Website.AdminEmail,
                Body = $"فاکتور جدید با شماره پیگیری {order.Id} به ثبت رسید لطفا جهت تایید به پنل خود مراجعه نمایید",
                Subject = "PocoPanel Factor"
            });
            #endregion

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
                throw new ApiException("سفارش مورد نظر یافت نشد.");

            if (orderDetail.tblProduct.tblProvider == null)
                throw new ApiException("سایت پذیرنده ای برای این محصول یافت نشد.");

            //Fill IProvider
            _IProvicerAsync = ProviderHelper.GetProvider(orderDetail.tblProduct.tblProvider);

            //check if Provider charge is enough
            var balance = await _IProvicerAsync.GetCredit();
            if (balance.balance == 0)
                throw new ApiException("موجودی حساب شما در سایت پذیرنده صفر میباشد.");

            var product = await _IProvicerAsync.GetProductById(orderDetail.tblProduct?.ProviderProductID ?? 0);
            if (product == null)
                throw new ApiException("محصول مورد نظر در سایت پذیرنده یافت نشد.");

            if (Convert.ToDecimal(product.rate * (orderDetail.Quantity / 1000)) > balance.balance)
                throw new ApiException("موجودی حساب شما در سایت پذیرنده کمتر از مقدار درخواستی میباشد.");


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
                orderDetail.ProviderOrderId = createOrderStatus.order;

                _dbContext.Entry(orderDetail).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return new Response<bool>(true, $"سفارش مورد نظر با شماره پیگیری از سایت پذیرنده {createOrderStatus.order} با موفقیت تایید شد.");
            }
            else
                throw new ApiException("ثبت سفارش از طرف سایت پذیرنده با خطا مواجه شد.");
        }

        public async Task<Response<bool>> RejectFactor(int orderDetailID, string reason)
        {
            //check if Order Exist
            var orderDetail = await _dbContext.tblOrderDetail.FindAsync(orderDetailID);
            if (orderDetail == null)
                throw new ApiException("سفارش مورد نظر یافت نشد.");

            orderDetail.tblStatusId = (int)Status.Rejected;
            _dbContext.Entry(orderDetail).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            //ToDo: Send Customer Email

            return new Response<bool>(true, "سفارش مورد با موفقیت حذف شد.");
        }

        public async Task<IEnumerable<AcceptOrderDetailViewModel>> GetAllWaitingOrderDetailsAsync()
        {
            var orderDetail = await _dbContext.tblOrderDetail
                .Include(tblOrderDetails => tblOrderDetails.tblOrder)
                .ThenInclude(tblOrderDetails => tblOrderDetails.tblPriceKind)
                .Where(tblOrderDetails => tblOrderDetails.tblStatusId == (int)Status.Waiting)
                .ToListAsync();

            return orderDetail.Select(orderDetails => new AcceptOrderDetailViewModel()
            {
                OrderId = orderDetails?.tblOrderId,
                OrderDetailId = orderDetails.Id,
                Price = _IConvert.RoundNumber(orderDetails.TotallPrice) + " " + orderDetails.tblOrder?.tblPriceKind?.Name,
                DateTime = _IConvert.PersionDateTime(orderDetails.Created)
            });
        }
        #endregion
    }
}
