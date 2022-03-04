using MediatR;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Providers.Commands
{
    public partial class ApplyAllProductsFromProviderCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
    }

    public class ApplyAllProductsFromProviderHandler : IRequestHandler<ApplyAllProductsFromProviderCommand, Response<bool>>
    {
        private readonly IProviderRepositoryAsync _ProviderRepository;

        public ApplyAllProductsFromProviderHandler(IProviderRepositoryAsync providerRepository)
        {
            _ProviderRepository = providerRepository;
        }

        public async Task<Response<bool>> Handle(ApplyAllProductsFromProviderCommand query, CancellationToken cancellationToken)
        {
            var isSuccess = await _ProviderRepository.ApplyAllProductsFromProviderAsync(query.Id);
            return isSuccess;
        }
    }
}
