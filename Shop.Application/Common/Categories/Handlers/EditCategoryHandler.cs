using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Products.Commands;
using Shop.Application.Exceptions;
using Shop.Infrastructure.Data;
using Z.EntityFramework.Plus;

namespace Shop.Application.Common.Products.Handlers;

public class EditCategoryHandler : IRequestHandler<EditCategoryCommand ,bool>
{
    private readonly ShopDbContext _context;
    private readonly IMapper _mapper ;

    public EditCategoryHandler(ShopDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request.CategoryDto.ParentCategoryId == request.CategoryDto.Id)
            throw new HttpException("Parent can't be same as your category", HttpStatusCode.BadRequest);
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryDto.Id, cancellationToken);
        _mapper.Map(request.CategoryDto, category);
        //await _context.Categories.UpdateAsync();
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}