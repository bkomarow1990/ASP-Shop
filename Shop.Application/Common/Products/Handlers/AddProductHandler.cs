using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
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
            //Path.GetDirectoryName()
            //var root = Path.Combine(_env.ContentRootPath, _env.ApplicationName, "Images", "Products");
// #if DEBUG
//             var assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
//             var assemblyDirectory = System.IO.Path.GetDirectoryName(assemblyPath);
// #else
//     var assemblyDirectory = System.AppContext.BaseDirectory;
// #endif
            //var root = Path.Combine(System.IO.Path.GetDirectoryName(), "Images", "Products");
            string root = !_env.IsDevelopment() ? 
                Path.Combine(_env.ContentRootPath, "Images", "Products")
                : Path.Combine(_env.ContentRootPath, _env.ApplicationName, "Images", "Products") ;
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
