using AutoMapper;
using MediatR;
using PocoPanel.Application.Features.Products.Queries.GetAllProducts;
using PocoPanel.Application.Filters;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Products.Queries.GetAllProductsByPage
{
    public class GetAllProductsByPageQuery : IRequest<PagedResponse<IEnumerable<GetAllProductsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsByPageQuery, PagedResponse<IEnumerable<GetAllProductsViewModel>>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllProductsViewModel>>> Handle(GetAllProductsByPageQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllProductsParameter>(request);
            return await _productRepository.GetAllProductsPagedReponseAsync(validFilter, request.IsDeleted);
        }
    }
}
