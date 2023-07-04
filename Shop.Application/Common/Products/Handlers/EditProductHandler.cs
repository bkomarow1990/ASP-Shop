using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Shop.Application.Common.Products.Commands;
using Shop.Application.Exceptions;
using Shop.Domain.Entities.Identity;
using Shop.Infrastructure.Data;

namespace Shop.Application.Common.Products.Handlers;

public class EditProductHandler : IRequestHandler<EditProductCommand, bool>
{
    private readonly IWebHostEnvironment _env;
    private readonly ShopDbContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public EditProductHandler(IWebHostEnvironment env, ShopDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _env = env;
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
       
        var product = _context.Products.FirstOrDefault(p => p.Id == request.EditProductDto.Id);
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
        {
            throw new HttpException("User not found", System.Net.HttpStatusCode.NotFound);
        }
        if (product == null || (product.UserId != request.UserId && !(await _userManager.IsInRoleAsync(user, "Administrator"))))
        {
            throw new HttpException("Product not found", HttpStatusCode.NotFound);
        }
        _mapper.Map(request.EditProductDto, product);
        if (request.EditProductDto.Image != null)
        {
            //var root = Path.Combine(Path.GetDirectoryName(_env.ContentRootPath), _env.ApplicationName, "Images", "Products");
            // var root = Path.Combine(_env.ContentRootPath, "Images", "Products");
            string root = !_env.IsDevelopment() ? 
                Path.Combine(_env.ContentRootPath, "Images", "Products")
                : Path.Combine(_env.ContentRootPath, _env.ApplicationName, "Images", "Products") ;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            var fileName = Guid.NewGuid() + Path.GetExtension(request.EditProductDto.Image.FileName);
            var filePath = Path.Combine(root, fileName);
            product.ImageName = fileName;
            await using var stream = new FileStream(filePath, FileMode.Create);
            await request.EditProductDto.Image.CopyToAsync(stream, cancellationToken);
        }
        
        await _context.SaveChangesAsync(cancellationToken);
        
        
        return true;
    }
}