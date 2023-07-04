using MediatR;
using Shop.Application.Collections;
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
using System.Linq.Expressions;
using Shop.Application.Common.Products.Queries;
using Shop.Domain.Entities;
using Shop.Application.Extensions;

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
            var query = _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Category)
                .AsNoTracking();
            var columnsFilter = new Dictionary<(string, bool), Expression<Func<Product, bool>>>
            {
                [("Id" ,request.RequestInfo.Id.HasValue)] = x => x.Id == request.RequestInfo.Id,
                [("Name", !string.IsNullOrWhiteSpace(request.RequestInfo.ProductName))] = x => x.Name.ToLower().Contains(request.RequestInfo.ProductName.ToLower()) || x.Description.ToLower().Contains(request.RequestInfo.ProductName.ToLower()),
                [("PriceRange", request.RequestInfo.PriceFrom.HasValue && request.RequestInfo.PriceTo.HasValue)] = x => request.RequestInfo.PriceFrom <= x.Price && request.RequestInfo.PriceTo >= x.Price,
                [("CategoryId", request.RequestInfo.CategoryId.HasValue)] = x => x.CategoryId != null && request.RequestInfo.CategoryId == x.CategoryId
            }; 
            var columnsOrder = new Dictionary<string, Expression<Func<Product, object>>>
            {
                ["price"] = x => x.Price,
                ["name"] = x => x.Name
            };

            query = query.ApplyFiltering(request.RequestInfo, columnsFilter);
            query = query.ApplyOrdering(request.RequestInfo, columnsOrder);
            var queryDto = query.ProjectTo<ResponseProductDto>(_mapper.ConfigurationProvider);
            return await queryDto.ToPagedListAsync(request.RequestInfo.PageIndex, request.RequestInfo.PageSize,
                cancellationToken);
            //return await _context.Products
            //    .AsNoTracking()
            //    .Include(p => p.Category)
            //    //.Where()
            //    .ProjectTo<ResponseProductDto>(_mapper.ConfigurationProvider)
            //    .ToPagedListAsync(request.RequestInfo.PageIndex , request.RequestInfo.PageSize, cancellationToken);

        }
    }
}
