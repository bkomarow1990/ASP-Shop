using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Categories.Queries;
using Shop.Application.DTO.Category;
using Shop.Infrastructure.Data;

namespace Shop.Application.Common.Categories.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesHandler(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories.Where(c => !c.ParentCategoryId.HasValue).ProjectTo<CategoryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}
