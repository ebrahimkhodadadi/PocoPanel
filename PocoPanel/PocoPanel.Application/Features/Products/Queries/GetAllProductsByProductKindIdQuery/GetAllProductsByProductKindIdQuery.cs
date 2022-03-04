using MediatR;
using PocoPanel.Application.DTOs.Products;
using PocoPanel.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Products.Queries.GetAllProductsByProductKindIdQuery
{
    public class GetAllProductsByProductKindIdQuery : IRequest<IEnumerable<GetAllProductsByProductKindViewModel>>
    {
        public int productKindId { get; set; }

        public class GetAllProductsByProductKindIdQueryHandler : IRequestHandler<GetAllProductsByProductKindIdQuery, IEnumerable<GetAllProductsByProductKindViewModel>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            public GetAllProductsByProductKindIdQueryHandler(IProductRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<IEnumerable<GetAllProductsByProductKindViewModel>> Handle(GetAllProductsByProductKindIdQuery query, CancellationToken cancellationToken)
            {
                var productViewModel = await _productRepository.GetAllProductsByProductKindIdAsync(query.productKindId);

                return productViewModel;
            }
        }
    }
}
