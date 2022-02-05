using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepositoryAsync productRepository;

        public CreateProductCommandValidator(IProductRepositoryAsync productRepository)
        {
            this.productRepository = productRepository;
        }
    }
}
