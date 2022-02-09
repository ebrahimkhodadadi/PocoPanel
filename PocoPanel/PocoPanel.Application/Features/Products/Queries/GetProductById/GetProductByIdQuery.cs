using MediatR;
using PocoPanel.Application.DTOs.Products;
using PocoPanel.Application.Exceptions;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using PocoPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<GetProductViewModel>>
    {
        public int Id { get; set; }
        public string Currency { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<GetProductViewModel>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            public GetProductByIdQueryHandler(IProductRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Response<GetProductViewModel>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var productViewModel = await _productRepository.GetProductViewModelByIdAsync(query.Id, query.Currency);
                if(productViewModel != null)
                    return new Response<GetProductViewModel>(productViewModel);

                throw new ApiException($"Product Not Found.");
            }
        }
    }
}
