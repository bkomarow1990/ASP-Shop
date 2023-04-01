using AutoMapper;
using MediatR;
using Shop.Application.Common.Products.Commands;
using Shop.Domain.Entities;
using Shop.Infrastructure.Data;

namespace Shop.Application.Common.Products.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public AddProductHandler(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDto);
            product.UserId = request.UserId;
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}
