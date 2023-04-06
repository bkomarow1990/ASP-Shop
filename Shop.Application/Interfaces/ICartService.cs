using Shop.Application.DTO.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
    public interface ICartService
    {
        Task<List<CartDto>> GetCartAsync(Guid userId);
        Task AddProductToCart(Guid productId, Guid userId, uint quantity);
        Task UpdateCartProduct(Guid productId, Guid userId, uint quantity);
        Task RemoveProductFromCart(Guid productId, Guid userId);
    }
}
