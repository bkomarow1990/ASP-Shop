using Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Collections;
using Shop.Application.DTO.Product;
using Shop.Application.Common.Products.Commands;
using Shop.Application.DTO.QueryTemplates;
using Shop.Application.Common.Products.Queries;

namespace Shop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Guid> AddProductAsync(Guid userId, AddProductDto addProductDto)
        {
            return await _mediator.Send(new AddProductCommand(addProductDto, userId));
        }

        public async Task DeleteProductAsync(Guid userId, Guid productId)
        {
            await _mediator.Send(new DeleteProductCommand(userId, productId));
        }

        public async Task<IPagedList<ResponseProductDto>> GetProducts(PageInfo pageInfo)
        {
            return await _mediator.Send(new GetProductsQuery(pageInfo));
        }
    }
}
