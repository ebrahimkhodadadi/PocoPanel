using MediatR;
using PocoPanel.Application.Exceptions;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Factors.Commands.Reject
{
    public class RejectFactorCommand : IRequest<Response<bool>>
    {
        public int orderDetailID { get; set; }
        public string reason { get; set; }

        public class RejectFactorCommandHandler : IRequestHandler<RejectFactorCommand, Response<bool>>
        {
            private readonly IFactorRepositoryAsync _FactorRepository;
            public RejectFactorCommandHandler(IFactorRepositoryAsync factorRepository)
            {
                _FactorRepository = factorRepository;
            }

            public async Task<Response<bool>> Handle(RejectFactorCommand request, CancellationToken cancellationToken)
            {
                var isSucceed = await _FactorRepository.RejectFactor(request.orderDetailID, request.reason);

                return isSucceed;
            }
        }
    }
}
