using MediatR;

namespace Shop.Application.Common.Products.Commands
{
    public record DeleteCategoryCommand(Guid CategoryId) : IRequest<bool>;
}
