using MediatR;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Factors.Commands.Accept
{
    public class AcceptFactorCommand : IRequest<Response<bool>>
    {
        public int orderDetailID { get; set; }
    }

    public class AcceptFactorCommandHandler : IRequestHandler<AcceptFactorCommand, Response<bool>>
    {
        private readonly IFactorRepositoryAsync _FactorRepository;
        public AcceptFactorCommandHandler(IFactorRepositoryAsync factorRepository)
        {
            _FactorRepository = factorRepository;
        }

        public async Task<Response<bool>> Handle(AcceptFactorCommand request, CancellationToken cancellationToken)
        {
            var isSucceed = await _FactorRepository.AcceptFactor(request.orderDetailID);

            return isSucceed;
        }
    }
}
