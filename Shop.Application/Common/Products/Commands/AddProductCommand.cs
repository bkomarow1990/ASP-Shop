using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.Product;

namespace Shop.Application.Common.Products.Commands
{
    public record AddProductCommand(AddProductDto ProductDto, Guid UserId) : IRequest<Guid>;
}
