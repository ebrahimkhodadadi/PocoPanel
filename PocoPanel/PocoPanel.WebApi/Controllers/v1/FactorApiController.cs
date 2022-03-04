using Microsoft.AspNetCore.Mvc;
using PocoPanel.Application.DTOs.Factors;
using PocoPanel.Application.Features.Factors.Commands.CreateFactor;
using PocoPanel.Application.Features.Orderdetails.Queries;
using PocoPanel.Application.Features.Orderdetails.Queries.GetOrderDetailById;
using PocoPanel.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocoPanel.WebApi.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    public class FactorApiController : BaseApiController
    {
        private readonly IGetUser _IGetUser;
        public FactorApiController(IGetUser iGetUser)
        {
            _IGetUser = iGetUser;
        }

        // POST <CreateOrder>
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(string ApiToken, [FromQuery] CreateFactorCommandViewModel command)
        {
            var user = await _IGetUser.GetUserByToken(ApiToken);
            if (user == null)
                return NotFound("User Not Found!");

            return Ok(await Mediator.Send(new CreateFactorCommand 
            { 
                CreatedBy = user.UserID,
                Currency = user.Currency,
                Description = command.Description,
                DiscountCode = command.DiscountCode,
                Quantity = command.Quantity,
                ServiceId = command.ServiceId,
                SocialUserName = command.SocialUserName
            }));
        }

        // POST <GetAllOrder>
        [HttpPost("GetAllOrder")]
        public async Task<IActionResult> GetAllOrder(string ApiToken)
        {
            var user = await _IGetUser.GetUserByToken(ApiToken);
            if (user == null)
                return NotFound("User Not Found!");

            return Ok(await Mediator.Send(new GetAllOrderDetailsQuery {UserID = user.UserID, Currency = user.Currency}));
        }

        //Post /<GetOrder>/5
        [HttpPost("GetOrder")]
        public async Task<IActionResult> GetOrder(string ApiToken, int id)
        {
            var user = await _IGetUser.GetUserByToken(ApiToken);
            if (user == null)
                return NotFound("User Not Found!");

            if (id == null || id == 0)
                return BadRequest();

            return Ok(await Mediator.Send(new GetOrderDetailByIdQuery { Id = id, Currency = user.Currency }));
        }
    }
}