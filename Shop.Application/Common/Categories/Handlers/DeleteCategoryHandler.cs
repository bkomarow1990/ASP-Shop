using AutoMapper;
using MediatR;
using Shop.Application.Common.Categories.Commands;
using Shop.Domain.Entities;
using Shop.Infrastructure.Data;

namespace Shop.Application.Common.Categories.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ShopDbContext _context;

        public DeleteCategoryHandler(ShopDbContext context, IMapper mapper)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category { Id = request.CategoryId };
            _context.Categories.Attach(category);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
