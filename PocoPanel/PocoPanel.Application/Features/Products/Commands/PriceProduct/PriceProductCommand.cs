using AutoMapper;
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

namespace PocoPanel.Application.Features.Products.Commands.PriceProduct
{
    public class PriceProductCommand : IRequest<Response<int>>
    {
        public int ProductId { get; set; }
        public decimal Rial { get; set; }
        public decimal USD { get; set; }

        public class PriceProductCommandHandler : IRequestHandler<PriceProductCommand, Response<int>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            private readonly IMapper _mapper;
            public PriceProductCommandHandler(IProductRepositoryAsync productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(PriceProductCommand command, CancellationToken cancellationToken)
            {
                var productPrice = _mapper.Map<ListProductPriceViewModel>(command);
                var product = await _productRepository.EditeProductPriceAsync(productPrice);
                
                return new Response<int>(command.ProductId);
            }
        }
    }
}
