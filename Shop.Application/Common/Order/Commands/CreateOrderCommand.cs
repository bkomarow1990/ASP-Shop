using MediatR;
using Shop.Application.DTO.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Order.Commands
{
    public record CreateOrderCommand(List<OrderItemDto> Products, Guid UserId) : IRequest<bool>;
}
