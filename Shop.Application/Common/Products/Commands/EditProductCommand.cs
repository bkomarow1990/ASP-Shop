using MediatR;
using Shop.Application.DTO.Product;

namespace Shop.Application.Common.Products.Commands;

public record EditProductCommand(Guid UserId, EditProductDto EditProductDto) : IRequest<bool>;