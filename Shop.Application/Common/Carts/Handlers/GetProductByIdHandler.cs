using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Carts.Queries;
using Shop.Application.DTO.Product;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Carts.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, DetailedProductDto>
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DetailedProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .ProjectTo<DetailedProductDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);
        }
    }
}
