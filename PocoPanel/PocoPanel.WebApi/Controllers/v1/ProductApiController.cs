using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PocoPanel.Application.Interfaces;
using PocoPanel.Application.Features.Products.Queries.GetProductById;
using PocoPanel.Application.Features.Products.Queries.GetAllProducts;

namespace PocoPanel.WebApi.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class ProductApiController : BaseApiController
    {
        private readonly IGetUser _IGetUser;
        public ProductApiController(IGetUser iGetUser)
        {
            _IGetUser = iGetUser;
        }

        // Post /<GetProduct>/5
        [HttpPost("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct(string ApiToken, int id)
        {
            var user = await _IGetUser.GetUserByToken(ApiToken);
            if (user == null)
                return NotFound("User Not Found!");

            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id, Currency = user.Currency }));
        }

        // Post /<GetAllProducts>
        [HttpPost("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts(string ApiToken)
        {
            var user = await _IGetUser.GetUserByToken(ApiToken);
            if (user == null)
                return NotFound("User Not Found!");

            return Ok(await Mediator.Send(new GetAllProductsQuery { Currency = user.Currency }));
        }

    }
}