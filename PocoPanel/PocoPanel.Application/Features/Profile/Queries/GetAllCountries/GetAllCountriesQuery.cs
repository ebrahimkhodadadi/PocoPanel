using MediatR;
using PocoPanel.Application.Exceptions;
using PocoPanel.Application.Interfaces;
using PocoPanel.Application.Wrappers;
using PocoPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PocoPanel.Application.Features.Profile.Queries.GetAllCountries
{
    public class GetAllCountriesQuery : IRequest<Response<IEnumerable<tblCountry>>>
    {
        public class GetAllCountryQueryHandler : IRequestHandler<GetAllCountriesQuery, Response<IEnumerable<tblCountry>>>
        {
            private readonly IGetInfo _GetUserInfo;

            public GetAllCountryQueryHandler(IGetInfo getUserInfo)
            {
                _GetUserInfo = getUserInfo;
            }
            public async Task<Response<IEnumerable<tblCountry>>> Handle(GetAllCountriesQuery query, CancellationToken cancellationToken)
            {
                var tblCountries = await _GetUserInfo.GetAllCountryAsync();
                return new Response<IEnumerable<tblCountry>>(tblCountries);
            }
        }
    }
}
