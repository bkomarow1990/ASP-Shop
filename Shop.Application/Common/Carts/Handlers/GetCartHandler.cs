using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Carts.Queries;
using Shop.Application.DTO.Cart;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Carts.Handlers
{
    public class GetCartHandler : IRequestHandler<GetCartQuery, List<CartDto>>
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public GetCartHandler(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CartDto>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            return await _context.Carts
                .AsNoTracking()
                .Include(c => c.Product)
                .Where(c => c.UserId == request.UserId)
                .ProjectTo<CartDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
