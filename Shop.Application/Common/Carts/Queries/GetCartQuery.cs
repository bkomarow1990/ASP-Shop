using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.DTO.Cart;
using Shop.Application.DTO.Product;

namespace Shop.Application.Common.Carts.Queries
{
    public record GetCartQuery(Guid UserId, List<Guid> ProductIds) : IRequest<List<ResponseProductDto>>;
}
