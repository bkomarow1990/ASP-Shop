using MediatR;
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
    public class RemoveFromCartHandler : IRequestHandler<RemoveProductFromCartCommand ,bool>
    {
        private readonly ShopDbContext _context;

        public RemoveFromCartHandler(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(RemoveProductFromCartCommand request, CancellationToken cancellationToken)
        {
            await _context.Carts
                .Where(c => c.ProductId == request.ProductId && c.UserId == request.UserId)
                .DeleteAsync(cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
