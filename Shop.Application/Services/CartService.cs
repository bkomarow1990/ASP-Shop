using Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Common.Carts.Queries;
using Shop.Application.Common.Carts.Commands;
using Shop.Application.DTO.Cart;

namespace Shop.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IMediator _mediator;
        public CartService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<List<CartDto>> GetCartAsync(Guid userId)
        {
            return await _mediator.Send(new GetCartQuery(userId));
        }

        public async Task AddProductToCart(Guid productId, Guid userId, uint quantity)
        {
            await _mediator.Send(new AddProductToCartCommand(userId, productId, quantity));
        }

        public async Task UpdateCartProduct(Guid productId, Guid userId, uint quantity)
        {
            await _mediator.Send(new UpdateCartProductCommand(userId, productId, quantity));
        }

        public async Task RemoveProductFromCart(Guid productId, Guid userId)
        {
            await _mediator.Send(new RemoveProductFromCartCommand(userId, productId));
        }
    }
}
