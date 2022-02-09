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

            RuleFor(p => p.Quantity)
                .NotEmpty().WithMessage("{PropertyName} Can not be emtpy.")
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.tblProductKindId)
            .NotEmpty().WithMessage("{PropertyName} Can not be emtpy.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MustAsync(IsExistProductKindId).WithMessage("Product Kind is not exists.");

            RuleFor(p => p.tblProviderId)
            .MustAsync(IsExistProviderId).WithMessage("Provider is not exists.");

        }

        private async Task<bool> IsExistProductKindId(int tblProductKindId, CancellationToken cancellationToken)
        {
            return await productRepository.IsExistProductKindId(tblProductKindId);
        }

        private async Task<bool> IsExistProviderId(int tblProviderId, CancellationToken cancellationToken)
        {
            return await productRepository.IsExistProviderId(tblProviderId);
        }
    }
}
