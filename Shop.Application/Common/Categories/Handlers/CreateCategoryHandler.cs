using AutoMapper;
using MediatR;
using Shop.Application.Common.Categories.Commands;
using Shop.Infrastructure.Data;

namespace Shop.Application.Common.Categories.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Guid?>
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid?> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Entities.Category>(request.CategoryDto);
            await _context.Categories.AddAsync(category , cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}
