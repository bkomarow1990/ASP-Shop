using Shop.Application.Collections;
using Shop.Application.DTO.Product;
using Shop.Application.DTO.QueryTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
    public interface IProductService
    {
        Task<Guid> AddProductAsync(Guid userId, AddProductDto addProductDto);
        Task DeleteProductAsync(Guid userId, Guid productId);
        Task<IPagedList<ResponseProductDto>> GetProducts(PageInfo pageInfo);
    }
}
