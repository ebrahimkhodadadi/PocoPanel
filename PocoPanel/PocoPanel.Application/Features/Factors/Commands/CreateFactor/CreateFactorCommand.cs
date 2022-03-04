using MediatR;
using PocoPanel.Application.Exceptions;
using PocoPanel.Application.Interfaces.Repositories;
using PocoPanel.Application.Wrappers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Factors.Commands.CreateFactor
{
    public partial class CreateFactorCommand : IRequest<Response<int>>
    {
        public string CreatedBy { get; set; }
        public string Currency { get; set; }

        public string Description { get; set; }
        [Required]
        public string SocialUserName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ServiceId { get; set; }

        public string DiscountCode { get; set; }
    }
    public class CreateFactorCommandHandler : IRequestHandler<CreateFactorCommand, Response<int>>
    {
        private readonly IFactorRepositoryAsync _FactorRepository;
        public CreateFactorCommandHandler(IFactorRepositoryAsync factorRepository)
        {
            _FactorRepository = factorRepository;
        }

        public async Task<Response<int>> Handle(CreateFactorCommand request, CancellationToken cancellationToken)
        {
            var factors = await _FactorRepository.CreateFactor(request);
            if(factors == null)
                return new Response<int>($"Create Factor Faild.");

            return new Response<int>(factors.Id, "Tracking Code");
        }
    }
}