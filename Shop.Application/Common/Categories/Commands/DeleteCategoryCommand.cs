using MediatR;

namespace Shop.Application.Common.Categories.Commands
{
    public record DeleteCategoryCommand(Guid CategoryId) : IRequest<bool>;
}
