using MediatR;
using Shop.Application.DTO.Category;

namespace Shop.Application.Common.Products.Commands;

public record EditCategoryCommand(EditCategoryDto CategoryDto) : IRequest<bool>;