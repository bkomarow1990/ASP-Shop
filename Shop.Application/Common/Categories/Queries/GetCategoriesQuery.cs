using MediatR;
using Shop.Application.DTO.Category;

namespace Shop.Application.Common.Categories.Queries
{
    public record GetCategoriesQuery() : IRequest<List<CategoryDto>>;
}
