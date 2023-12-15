using MediatR;
using Microsoft.AspNetCore.Identity;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Products.Commands;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using Shop.Domain.Entities.Identity;

namespace Shop.Application.Common.Products.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly ShopDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteProductHandler(ShopDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                throw new HttpException("User not found", System.Net.HttpStatusCode.NotFound);
            }
            var product = await _context.Products
                .Where(p => p.Id == request.ProductId)
                .Select(p => new Product{Id = p.Id, UserId = p.UserId })
                .FirstOrDefaultAsync(cancellationToken);
            //.AsNoTracking()
            if ((await _userManager.IsInRoleAsync(user, "Administrator")) || product.UserId == request.UserId)
            {
                //_context.Products.Attach(product);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new HttpException("Product not found!", System.Net.HttpStatusCode.NotFound);
            }
            return true;
            
        }
    }
}
