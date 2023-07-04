using MediatR;
using Shop.Application.DTO.Category;

namespace Shop.Application.Common.Products.Queries
{
    public record GetCategoriesQuery(bool isOnlyWithParent) : IRequest<List<CategoryDto>>;
}
