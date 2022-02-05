using MediatR;
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
    public class GetProductByIdQuery : IRequest<Response<tblProduct>>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<tblProduct>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            public GetProductByIdQueryHandler(IProductRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Response<tblProduct>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(query.Id);
                if (product == null) throw new ApiException($"Product Not Found.");
                return new Response<tblProduct>(product);
            }
        }
    }
}
