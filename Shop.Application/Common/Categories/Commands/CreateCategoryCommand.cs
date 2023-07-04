using MediatR;
using Shop.Application.DTO.Category;

namespace Shop.Application.Common.Products.Commands
{
    public record CreateCategoryCommand(AddCategoryDto CategoryDto) : IRequest<Guid?>;
}
