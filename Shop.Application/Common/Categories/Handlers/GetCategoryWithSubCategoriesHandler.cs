using System.Net;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Products.Queries;
using Shop.Application.DTO.Category;
using Shop.Application.Exceptions;
using Shop.Infrastructure.Data;

namespace Shop.Application.Common.Products.Handlers;

public class GetCategoryWithSubCategoriesHandler : IRequestHandler<GetCategoryWithSubCategoriesQuery, CategoryWithSubCategoriesDto>
{
    private readonly ShopDbContext _context;
    private readonly IMapper _mapper;
    
    public GetCategoryWithSubCategoriesHandler(ShopDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryWithSubCategoriesDto> Handle(GetCategoryWithSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories
                .AsNoTracking()
                .Where(c => c.Id == request.CategoryId)
                .ProjectTo<CategoryWithSubCategoriesDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        if (category is null) throw new HttpException("Category not found", HttpStatusCode.NotFound);
        return category;
    }
}