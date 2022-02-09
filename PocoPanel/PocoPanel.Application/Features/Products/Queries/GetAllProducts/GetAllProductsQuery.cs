using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PocoPanel.Application.DTOs.Products;
using PocoPanel.Application.Exceptions;
using PocoPanel.Application.Interfaces;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;

namespace PocoPanel.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<Response<IEnumerable<GetProductViewModel>>>
    {
        public string Currency { get; set; }

        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, Response<IEnumerable<GetProductViewModel>>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            private readonly IAuthenticatedUserService _authenticatedUser;

            public GetAllProductQueryHandler(IProductRepositoryAsync productRepository, IAuthenticatedUserService authenticatedUser)
            {
                _productRepository = productRepository;
                _authenticatedUser = authenticatedUser;
            }
            public async Task<Response<IEnumerable<GetProductViewModel>>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                string currency;
                if (!string.IsNullOrWhiteSpace(query.Currency))
                    currency = query.Currency;
                else
                    currency = _authenticatedUser.Currency;

                var productViewModel = await _productRepository.GetProductViewModelByIdAsync(currency);
                if (productViewModel.Count() > 0)
                    return new Response<IEnumerable<GetProductViewModel>>(productViewModel);

                throw new ApiException($"Products Not Found.");
            }
        }
    }
}