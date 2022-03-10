using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocoPanel.Application.Features.Products.Commands.CreateProduct;
using PocoPanel.Application.Features.Products.Commands.DeleteProductById;
using PocoPanel.Application.Features.Products.Commands.PriceProduct;
using PocoPanel.Application.Features.Products.Commands.UpdateProduct;
using PocoPanel.Application.Features.Products.Queries.GetAllProducts;
using PocoPanel.Application.Features.Products.Queries.GetAllProductsByPage;
using PocoPanel.Application.Features.Products.Queries.GetAllProductsByProductKindIdQuery;
using PocoPanel.Application.Features.Products.Queries.GetProductById;
using PocoPanel.Application.Features.Products.Queries.GetProductDetailById;
using PocoPanel.Application.Features.Products.Queries.GetProductPricesById;

namespace PocoPanel.WebApi.Controllers.Authorized
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet("GetAllProductsKindId")]
        public async Task<IActionResult> GetAllProductsKindId(int KindId)
        {
            return Ok(await Mediator.Send(new GetAllProductsByProductKindIdQuery() { productKindId = KindId }));
        }

        // Post: /<GetAllProductsByPage>/
        [HttpPost("GetAllProductsByPage")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllProductsByPage([FromBody] GetAllProductsByPageQuery filter)
        {
            return Ok(await Mediator.Send(new GetAllProductsByPageQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber, IsDeleted = filter.IsDeleted }));
        }

        // Post: /<GetAllProducts>/
        [HttpPost("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery() { }));
        }

        // Post /<GetProductDetail>/5
        [HttpPost("GetProductDetail")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetProductDetail(int id)
        {    
            return Ok(await Mediator.Send(new GetProductDetailByIdQuery { Id = id }));
        }

        // Post /<GetProductPrices>/5
        [HttpPost("GetProductPrices")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetProductPrices(int id)
        {
            return Ok(await Mediator.Send(new GetProductPricesByIdQuery { Id = id }));
        }

        // POST <CreateProduct>
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        // POST api/<controller>/5
        [HttpPost("EditeProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditeProduct(UpdateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        
        // Post api/<controller>/5
        [HttpPost("DeleteProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }


        // POST api/<EditePriceProduct>/5
        [HttpPost("EditePriceProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditePriceProduct(PriceProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        

    }
}