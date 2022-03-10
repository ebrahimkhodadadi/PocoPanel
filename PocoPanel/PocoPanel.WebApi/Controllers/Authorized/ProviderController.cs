using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocoPanel.Application.Features.Providers.Commands;
using PocoPanel.Application.Features.Providers.Queries.GetAllProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanel.WebApi.Controllers.Authorized
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProviderController : BaseApiController
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllProviders")]
        public async Task<IActionResult> GetAllProviders()
        {
            return Ok(await Mediator.Send(new GetAllProvidersQuery { }));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("ApplyAllProductsFromProvider")]
        public async Task<IActionResult> ApplyAllProductsFromProvider(int Id)
        {
            return Ok(await Mediator.Send(new ApplyAllProductsFromProviderCommand { Id = Id }));
        }
    }
}
