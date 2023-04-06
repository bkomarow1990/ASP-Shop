using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Common.Carts.Commands;
using Shop.Application.DTO.Cart;
using Shop.Application.Interfaces;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [Authorize]
        [HttpGet("get-cart")]
        public async Task<ActionResult<List<CartDto>>> GetUserCart()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await _cartService.GetCartAsync(userId));
        }
        [Authorize]
        [HttpPut("add-product-to-cart")]
        public async Task<ActionResult> AddProductToCart([FromBody] AddProductToCartRequest addProductToCartRequest)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _cartService.AddProductToCart(addProductToCartRequest.ProductId, userId, addProductToCartRequest.Quantity);
            return Ok();
        }

        [Authorize]
        [HttpDelete("remove-cart-product")]
        public async Task<ActionResult> RemoveCartProduct(Guid productId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _cartService.RemoveProductFromCart(productId, userId);
            return Ok();
        }

        [Authorize]
        [HttpPut("updateCartCartProduct")]
        public async Task<ActionResult> UpdateCartProduct(Guid productId, uint quantity)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _cartService.UpdateCartProduct(productId, userId, quantity);
            return Ok();
        }
    }
}
