using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Shop.Application.Common.Products.Commands;
using Shop.Domain.Entities;
using Shop.Infrastructure.Data;

namespace Shop.Application.Common.Products.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IWebHostEnvironment _env;
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public AddProductHandler(ShopDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var root = Path.Combine(Path.GetDirectoryName(_env.ContentRootPath), _env.ApplicationName, "Images", "Products");
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            var fileName = Guid.NewGuid() + Path.GetExtension(request.ProductDto.Image.FileName);
            var filePath = Path.Combine(root, fileName);

            var product = _mapper.Map<Product>(request.ProductDto);
            product.UserId = request.UserId;
            product.ImageName = fileName;
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.ProductDto.Image.CopyToAsync(stream, cancellationToken);
            }
            return product.Id;
        }
    }
}
