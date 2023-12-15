using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Common.Order.Commands;
using Shop.Application.DTO.OrderItem;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;

namespace Shop.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMediator _mediator;

        public OrderService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> HandleCart(List<OrderItemDto> products, Guid userId)
        {
            var response = await _mediator.Send(new CreateOrderCommand(products, userId));
            if (!response)
            {
                throw new HttpException("Error with handle cart!", HttpStatusCode.BadRequest);
            }
            return true;
        }
    }
}
