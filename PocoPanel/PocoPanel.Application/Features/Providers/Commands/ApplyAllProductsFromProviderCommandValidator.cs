using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.Features.Providers.Commands
{
    public class ApplyAllProductsFromProviderCommandValidator : AbstractValidator<ApplyAllProductsFromProviderCommand>
    {
        public ApplyAllProductsFromProviderCommandValidator()
        {

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} Can not be emtpy.")
                .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
