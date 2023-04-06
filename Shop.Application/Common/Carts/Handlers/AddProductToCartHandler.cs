using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Carts.Commands;
using Shop.Infrastructure.Data;

namespace Shop.Application.Common.Carts.Handlers
{
    public class AddProductToCartHandler : IRequestHandler<AddProductToCartCommand, bool> 
    {
        private readonly ShopDbContext _context;

        public AddProductToCartHandler(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            var cartItem =
                await _context.Carts.FirstOrDefaultAsync(c =>
                    c.UserId == request.UserId && c.ProductId == request.ProductId, cancellationToken);
            if (cartItem == null)
            {
                await _context.Carts.AddAsync(new Domain.Entities.Cart
                {
                    UserId = request.UserId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    DateCreated = DateTime.UtcNow
                }, cancellationToken);
            }
            else
            {
                cartItem.Quantity += request.Quantity;
            }
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
