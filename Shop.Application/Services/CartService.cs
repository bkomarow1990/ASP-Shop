using Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Common.Carts.Queries;
using Shop.Application.DTO.Cart;
using Shop.Application.DTO.Product;

namespace Shop.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IMediator _mediator;
        public CartService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<List<ResponseProductDto>> GetCartAsync(Guid userId, List<Guid> productIds)
        {
            return await _mediator.Send(new GetCartQuery(userId, productIds));
        }
    }
}
