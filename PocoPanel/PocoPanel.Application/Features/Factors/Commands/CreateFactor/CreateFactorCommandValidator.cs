using FluentValidation;
using PocoPanel.Application.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Factors.Commands.CreateFactor
{
    public class CreateFactorCommandValidator : AbstractValidator<CreateFactorCommand>
    {
         private readonly IFactorRepositoryAsync _factorRepositoryAsync;

        public CreateFactorCommandValidator(IFactorRepositoryAsync factorRepositoryAsync)
        {
            this._factorRepositoryAsync = factorRepositoryAsync;

            RuleFor(p => p.SocialUserName)
            .NotEmpty().WithMessage("{PropertyName} Can not be emtpy.")
            .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Quantity)
            .NotEmpty().WithMessage("{PropertyName} Can not be emtpy.")
            .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ServiceId)
            .NotEmpty().WithMessage("{PropertyName} Can not be emtpy.")
            .NotNull().WithMessage("{PropertyName} is required.")
            .MustAsync(IsExistProductId).WithMessage("Service is not exists.");
        }

        private async Task<bool> IsExistProductId(int ServiceId, CancellationToken cancellationToken)
        {
            return await _factorRepositoryAsync.IsExistProductId(ServiceId);
        }
    }
}