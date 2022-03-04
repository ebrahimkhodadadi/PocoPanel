using MediatR;
using PocoPanel.Application.DTOs.Providers;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Providers.Queries.GetAllProviders
{
    public class GetAllProvidersQuery : IRequest<Response<IEnumerable<ProvidersViewModel>>>
    {
        public class GetAllProvidersQueryHandler : IRequestHandler<GetAllProvidersQuery, Response<IEnumerable<ProvidersViewModel>>>
        {
            private readonly IProviderRepositoryAsync _ProviderRepository;

            public GetAllProvidersQueryHandler(IProviderRepositoryAsync providerRepository)
            {
                _ProviderRepository = providerRepository;
            }
            public async Task<Response<IEnumerable<ProvidersViewModel>>> Handle(GetAllProvidersQuery query, CancellationToken cancellationToken)
            {
                var providersViewModel = await _ProviderRepository.GetAllProvidersViewModelAsync();
                return new Response<IEnumerable<ProvidersViewModel>>(providersViewModel);
            }
        }
    }
}
