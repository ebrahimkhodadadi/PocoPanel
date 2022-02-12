using MediatR;
using PocoPanel.Application.DTOs.Factors;
using PocoPanel.Application.Exceptions;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Orderdetails.Queries.GetOrderDetailById
{
    public class GetOrderDetailByIdQuery : IRequest<Response<OrderDetailViewModel>>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Currency { get; set; }

        public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, Response<OrderDetailViewModel>>
        {
            private readonly IOrderDetailRepositoryAsync _OrderDetailRepository;
            public GetOrderDetailByIdQueryHandler(IOrderDetailRepositoryAsync orderDetailRepository)
            {
                _OrderDetailRepository = orderDetailRepository;
            }
            public async Task<Response<OrderDetailViewModel>> Handle(GetOrderDetailByIdQuery query, CancellationToken cancellationToken)
            {
                var orderDetailViewModel = await _OrderDetailRepository.GetOrderDetailViewModelByIdAsync(query.UserId, query.Id, query.Currency);
                if (orderDetailViewModel != null)
                    return new Response<OrderDetailViewModel>(orderDetailViewModel);

                throw new ApiException($"Order Not Found.");
            }
        }
    }
}
