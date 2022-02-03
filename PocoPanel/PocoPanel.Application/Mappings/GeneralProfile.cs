using AutoMapper;
using PocoPanel.Application.Features.Products.Commands.CreateProduct;
using PocoPanel.Application.Features.Products.Queries.GetAllProducts;
using PocoPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
