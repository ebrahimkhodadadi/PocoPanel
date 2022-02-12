using MediatR;
using PocoPanel.Application.DTOs.Factors;
using PocoPanel.Application.Exceptions;
using PocoPanel.Application.Interfaces;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Orderdetails.Queries
{
    public class GetAllOrderDetailsQuery : IRequest<Response<IEnumerable<OrderDetailViewModel>>>
    {
        public string UserID { get; set; }
        public string Currency { get; set; }

        public class GetAllOrderDetailsQueryHandler : IRequestHandler<GetAllOrderDetailsQuery, Response<IEnumerable<OrderDetailViewModel>>>
        {
            private readonly IOrderDetailRepositoryAsync _OrderDetailRepository;
            private readonly IAuthenticatedUserService _authenticatedUser;

            public GetAllOrderDetailsQueryHandler(IOrderDetailRepositoryAsync orderDetailRepository, IAuthenticatedUserService authenticatedUser)
            {
                _OrderDetailRepository = orderDetailRepository;
                _authenticatedUser = authenticatedUser;
            }
            public async Task<Response<IEnumerable<OrderDetailViewModel>>> Handle(GetAllOrderDetailsQuery query, CancellationToken cancellationToken)
            {
                var orderDetailViewModel = await _OrderDetailRepository.GetOrderDetailViewModelAsync(query.UserID, query.Currency);
                if (orderDetailViewModel.Count() > 0)
                    return new Response<IEnumerable<OrderDetailViewModel>>(orderDetailViewModel);

                throw new ApiException($"Orders Not Found.");
            }
        }
    }
}