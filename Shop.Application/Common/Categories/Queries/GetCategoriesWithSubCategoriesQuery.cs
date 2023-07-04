using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.Category;

namespace Shop.Application.Common.Products.Queries
{
    public record GetCategoriesWithSubCategoriesQuery() : IRequest<List<CategoryWithSubCategoriesDto>>;
}
