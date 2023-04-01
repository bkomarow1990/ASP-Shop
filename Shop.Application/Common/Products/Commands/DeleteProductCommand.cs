using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.Common.Products.Commands
{
    public record DeleteProductCommand(Guid UserId, Guid ProductId) : IRequest<bool>;
}
