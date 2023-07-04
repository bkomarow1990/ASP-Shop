using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Collections;
using Shop.Application.DTO.Product;
using Shop.Application.DTO.QueryTemplates;
using Shop.Application.Interfaces;
using System.Security.Claims;
using Shop.API.Extensions;
using Shop.Application.Exceptions;

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

        [HttpGet("get-product-by-id")]
        public async Task<ActionResult<DetailedProductDto>> GetProductById([FromQuery] Guid productId)
        {
            return await _productService.GetProductById(productId);
        }
        [Authorize(Roles="Administrator")]
        [HttpPost("add-product")]
        public async Task<ActionResult<Guid>> AddProduct([FromQuery] Guid? userId,[FromForm] AddProductDto addProductDto)
        {
            // if (!Request.Form.IsMimeMultipartContent())
            // {
            //     throw new HttpException("Unsupported media!",HttpStatusCode.UnsupportedMediaType);
            // }
            var claimUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var file = addProductDto.Image;
            // if (file == null || file.Length == 0)
            // {
            //     return BadRequest("No file uploaded.");
            // }

            if (file != null && !FileExtensions.IsImageFile(file.FileName))
            {
                return BadRequest("Invalid file format. Only image files are allowed.");
            }

            // Rest of the code for handling the image upload
            return Ok(await _productService.AddProductAsync(userId ?? claimUserId, addProductDto));
        }
        [Authorize]
        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _productService.DeleteProductAsync(userId, productId);
            return Ok();
        }

        [Authorize]
        [HttpPost("edit-product")]
        public async Task<ActionResult> EditProduct([FromQuery] Guid? userId,
            [FromForm] EditProductDto editProductDto)
        {
            var claimUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var file = editProductDto.Image;
            if (file != null && !FileExtensions.IsImageFile(file.FileName))
            {
                return BadRequest("Invalid file format. Only image files are allowed.");
            }

            await _productService.EditProductAsync(userId ?? claimUserId, editProductDto);
            return Ok();
        }

        [HttpGet("get-products")]
        public async Task<ActionResult<IPagedList<ResponseProductDto>>> GetProducts([FromQuery] RequestProductsDto requestProductsDto)
        {
            return Ok(await _productService.GetProducts(requestProductsDto));
        }
    }
}
