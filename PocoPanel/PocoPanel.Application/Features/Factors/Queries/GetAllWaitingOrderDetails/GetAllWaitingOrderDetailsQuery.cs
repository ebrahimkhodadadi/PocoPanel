using MediatR;
using PocoPanel.Application.DTOs.Factors;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Factors.Queries.GetAllWaitingOrderDetails
{
    public class GetAllWaitingOrderDetailsQuery : IRequest<Response<IEnumerable<AcceptOrderDetailViewModel>>>
    {
        public class GetAllWaitingOrderDetailsHandler : IRequestHandler<GetAllWaitingOrderDetailsQuery, Response<IEnumerable<AcceptOrderDetailViewModel>>>
        {
            private readonly IFactorRepositoryAsync _FactorRepository;
            public GetAllWaitingOrderDetailsHandler(IFactorRepositoryAsync factorRepository)
            {
                _FactorRepository = factorRepository;
            }
            public async Task<Response<IEnumerable<AcceptOrderDetailViewModel>>> Handle(GetAllWaitingOrderDetailsQuery query, CancellationToken cancellationToken)
            {
                var orderDetailsViewModel = await _FactorRepository.GetAllWaitingOrderDetailsAsync();
                return new Response<IEnumerable<AcceptOrderDetailViewModel>>(orderDetailsViewModel);
            }
        }
    }
}
