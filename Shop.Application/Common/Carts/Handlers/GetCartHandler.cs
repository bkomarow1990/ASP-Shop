using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Carts.Queries;
using Shop.Application.DTO.Cart;
using Shop.Application.DTO.Product;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Carts.Handlers
{
    public class GetCartHandler : IRequestHandler<GetCartQuery, List<ResponseProductDto>>
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public GetCartHandler(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResponseProductDto>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(c => request.ProductIds.Contains(c.Id))
                .ProjectTo<ResponseProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
