using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.OrderItem;

namespace Shop.Application.Interfaces
{
    public interface IOrderService
    {
        Task<bool> HandleCart(List<OrderItemDto> products, Guid userId);
    }
}
