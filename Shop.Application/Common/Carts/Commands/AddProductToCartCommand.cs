using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.Common.Carts.Commands
{
    public record AddProductToCartCommand(Guid UserId, Guid ProductId, uint Quantity) : IRequest<bool>;
}
