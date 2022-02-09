using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocoPanel.Application.Features.Products.Commands.CreateProduct;
using PocoPanel.Application.Features.Products.Commands.DeleteProductById;
using PocoPanel.Application.Features.Products.Commands.UpdateProduct;
using PocoPanel.Application.Features.Products.Queries.GetAllProducts;
using PocoPanel.Application.Features.Products.Queries.GetAllProductsByPage;
using PocoPanel.Application.Features.Products.Queries.GetProductById;

namespace PocoPanel.WebApi.Controllers.Authorized
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProductController : BaseApiController
    {

        // Post: /<GetAllProductsByPage>/
        [HttpPost("GetAllProductsByPage")]
        public async Task<IActionResult> GetAllProductsByPage([FromQuery] GetAllProductsByPageQuery filter)
        {
            return Ok(await Mediator.Send(new GetAllProductsByPageQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // Post: /<GetAllProducts>/
        [HttpPost("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery() { }));
        }

        // Post /<GetProduct>/5
        [HttpPost("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }

        // POST <CreateProduct>
        //[ApiExplorerSettings(IgnoreApi = true)]
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /*
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
        */
    }
}