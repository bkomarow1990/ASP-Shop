﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.DTO.Cart;

namespace Shop.Application.Common.Carts.Queries
{
    public record GetCartQuery(Guid UserId) : IRequest<List<CartDto>>;
}
