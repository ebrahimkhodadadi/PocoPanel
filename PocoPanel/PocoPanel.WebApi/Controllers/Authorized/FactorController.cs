using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocoPanel.Application.Features.Factors.Commands.Accept;
using PocoPanel.Application.Features.Factors.Commands.Reject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanel.WebApi.Controllers.Authorized
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class FactorController : BaseApiController
    {
       // POST<AcceptFactor>
       [Authorize(Roles = "Admin")]
       [HttpPost("AcceptFactor")]
        public async Task<IActionResult> AccepteFactor([FromQuery]AcceptFactorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

       // POST<RejectFactor>
       [Authorize(Roles = "Admin")]
       [HttpPost("RejectFactor")]
        public async Task<IActionResult> RejecteFactor([FromQuery]RejectFactorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
