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
using Shop.Application.Common.Carts.Queries;
using Shop.Application.Exceptions;
using System.Reflection.Metadata.Ecma335;

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

        public async Task EditProductAsync(Guid userId, EditProductDto editProductDto)
        {
            await _mediator.Send(new EditProductCommand(userId, editProductDto));
        }

        public async Task DeleteProductAsync(Guid userId, Guid productId)
        {
            await _mediator.Send(new DeleteProductCommand(userId, productId));
        }

        public async Task<IPagedList<ResponseProductDto>> GetProducts(RequestProductsDto requestInfo)
        {
            return await _mediator.Send(new GetProductsQuery(requestInfo));
        }

        public async Task<DetailedProductDto> GetProductById(Guid productId)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(productId));
            if (product is null) throw new HttpException("product not found", System.Net.HttpStatusCode.NotFound);
            return product;
        }
    }
}
