using MediatR;
using Shop.Application.Collections;
using Shop.Application.Common.Products.Queries;
using Shop.Application.DTO.Product;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Shop.Application.Common.Products.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IPagedList<ResponseProductDto>>
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsHandler(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IPagedList<ResponseProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                //.Where()
                .ProjectTo<ResponseProductDto>(_mapper.ConfigurationProvider)
                .ToPagedListAsync(request.PageInfo.PageIndex , request.PageInfo.PageSize, cancellationToken);

        }
    }
}
