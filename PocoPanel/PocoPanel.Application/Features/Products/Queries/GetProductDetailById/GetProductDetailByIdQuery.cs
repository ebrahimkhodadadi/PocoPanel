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

namespace PocoPanel.Application.Features.Products.Queries.GetProductDetailById
{
    public class GetProductDetailByIdQuery : IRequest<Response<GetProductDetailViewModel>>
    {
        public int Id { get; set; }

        public class GetProductDetailByIdQueryHandler : IRequestHandler<GetProductDetailByIdQuery, Response<GetProductDetailViewModel>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            public GetProductDetailByIdQueryHandler(IProductRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Response<GetProductDetailViewModel>> Handle(GetProductDetailByIdQuery query, CancellationToken cancellationToken)
            {
                if (query.Id == 0)
                    throw new ApiException($"Product Not Found.");

                var productViewModel = await _productRepository.GetProductDetailViewModelByIdAsync(query.Id);
                if (productViewModel != null)
                    return new Response<GetProductDetailViewModel>(productViewModel);

                throw new ApiException($"Product Not Found.");
            }
        }
    }
}