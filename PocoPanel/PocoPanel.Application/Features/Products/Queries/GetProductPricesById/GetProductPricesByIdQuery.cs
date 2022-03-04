using MediatR;
using PocoPanel.Application.DTOs.Products;
using PocoPanel.Application.Exceptions;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Products.Queries.GetProductPricesById
{
    public class GetProductPricesByIdQuery : IRequest<Response<ListProductPriceViewModel>>
    {
        public int Id { get; set; }

        public class GetProductPricesByIdQueryHandler : IRequestHandler<GetProductPricesByIdQuery, Response<ListProductPriceViewModel>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            public GetProductPricesByIdQueryHandler(IProductRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Response<ListProductPriceViewModel>> Handle(GetProductPricesByIdQuery query, CancellationToken cancellationToken)
            {
                if (query.Id == 0)
                    throw new ApiException($"Product Not Found.");

                var productPriceViewModel = await _productRepository.GetProductPricesById(query.Id);
                
                return new Response<ListProductPriceViewModel>(productPriceViewModel);
            }
        }
    }
}