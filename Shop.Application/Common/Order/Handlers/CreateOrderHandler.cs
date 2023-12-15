using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Common.Order.Commands;
using Shop.Domain.Entities;
using Shop.Infrastructure.Data;

namespace Shop.Application.Common.Order.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly ShopDbContext _context;
        public CreateOrderHandler(ShopDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var order = new Domain.Entities.Order {ApplicationUserId = request.UserId};
                await _context.Orders.AddAsync(order,
                    cancellationToken);
                _context.OrderItems.AddRange(request.Products
                    .Select(x => new OrderItem {ProductId = x.ProductId, Quantity = x.Quantity, Order = order}).ToArray());
                await _context.SaveChangesAsync(cancellationToken);
                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                await transaction.CommitAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
