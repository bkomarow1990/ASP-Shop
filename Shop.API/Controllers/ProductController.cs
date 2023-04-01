using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Collections;
using Shop.Application.DTO.Product;
using Shop.Application.DTO.QueryTemplates;
using Shop.Application.Interfaces;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize]
        [HttpPost("add-product")]
        public async Task<ActionResult<Guid>> AddProduct(Guid userId, AddProductDto addProductDto)
        {
            return Ok(await _productService.AddProductAsync(userId, addProductDto));
        }

        [Authorize]
        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _productService.DeleteProductAsync(productId,  userId);
            return Ok();
        }

        [HttpGet("get-products")]
        public async Task<ActionResult<IPagedList<ResponseProductDto>>> GetProducts([FromQuery] PageInfo pageInfo)
        {
            return Ok(await _productService.GetProducts(pageInfo));
        }
    }
}
