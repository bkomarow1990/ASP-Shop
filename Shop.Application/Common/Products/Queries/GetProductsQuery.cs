using MediatR;
using Shop.Application.Collections;
using Shop.Application.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.QueryTemplates;

namespace Shop.Application.Common.Products.Queries
{
    public record GetProductsQuery(RequestProductsDto RequestInfo) : IRequest<IPagedList<ResponseProductDto>>;
}
