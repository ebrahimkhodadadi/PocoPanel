using FluentValidation;
using PocoPanel.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepositoryAsync productRepository;

        public UpdateProductCommandValidator(IProductRepositoryAsync productRepository)
        {
            this.productRepository = productRepository;

            RuleFor(p => p.Decending)
                .NotEmpty().WithMessage("{PropertyName} Can not be emtpy.")
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} Can not be emtpy.")
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} Can not be emtpy.")
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} Can not be emtpy.")
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.QualityId)
                .NotEmpty().WithMessage("{PropertyName} Can not be emtpy.")
                .NotNull().WithMessage("{PropertyName} is required.");

        }
    }
}