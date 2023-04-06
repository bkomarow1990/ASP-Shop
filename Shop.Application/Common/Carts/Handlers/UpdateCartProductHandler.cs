using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Carts.Commands;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Shop.Application.Common.Carts.Handlers
{
    public class UpdateCartProductHandler : IRequestHandler<UpdateCartProductCommand, bool>
    {
        private readonly ShopDbContext _context;

        public UpdateCartProductHandler(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCartProductCommand request, CancellationToken cancellationToken)
        {
            await _context.Carts
                .AnyAsync(
                    c => c.UserId == request.UserId && c.ProductId == request.ProductId, 
                    cancellationToken
                    );
            // Update the property using the Update method
            await _context.Carts.Where(x => x.UserId == request.UserId && x.ProductId == request.ProductId)
                .UpdateAsync(x => new Domain.Entities.Cart {  Quantity = request.Quantity }, cancellationToken);
             
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
