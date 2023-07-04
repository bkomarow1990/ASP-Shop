using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTO.Cart;
using Shop.Application.Interfaces;
using System.Security.Claims;
using Shop.Application.DTO.Product;
using Shop.Application.DTO.OrderItem;

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
        public async Task<ActionResult<List<ResponseProductDto>>> GetUserCart([FromQuery(Name = "productsIds")] string productsIds)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var productIdsList = productsIds.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var guidList = new List<Guid>();
            foreach (var productId in productIdsList)
            {
                if (Guid.TryParse(productId, out Guid guid))
                {
                    guidList.Add(guid);
                }
                else
                {
                    // handle invalid GUID format
                    return BadRequest($"Invalid GUID format: {productId}");
                }
            }
            //.Select(pid => Guid.Parse(pid))
            return Ok(await _cartService.GetCartAsync(userId, guidList));
        }
    }
}
