using AutoMapper;
using MediatR;
using Shop.Application.Common.Categories.Queries;
using Shop.Application.DTO.Category;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Common.Categories.Handlers
{
    public class GetCategoriesWithSubCategoriesHandler : IRequestHandler<GetCategoriesWithSubCategoriesQuery, List<CategoryWithSubCategoriesDto>>
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesWithSubCategoriesHandler(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryWithSubCategoriesDto>> Handle(GetCategoriesWithSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories.AsNoTracking().Include(c => c.Subcategories).Where(c => !c.ParentCategoryId.HasValue).ProjectTo<CategoryWithSubCategoriesDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}
