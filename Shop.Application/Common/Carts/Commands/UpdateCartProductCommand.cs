using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Carts.Commands
{
    public record UpdateCartProductCommand(Guid UserId, Guid ProductId, uint Quantity) : IRequest<bool>;
}
