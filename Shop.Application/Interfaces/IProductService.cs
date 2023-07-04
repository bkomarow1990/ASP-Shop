using Shop.Application.Collections;
using Shop.Application.DTO.Product;
using Shop.Application.DTO.QueryTemplates;

namespace Shop.Application.Interfaces
{
    public interface IProductService
    {
        Task<Guid> AddProductAsync(Guid userId, AddProductDto addProductDto);
        Task EditProductAsync(Guid userId, EditProductDto editProductDto);
        Task DeleteProductAsync(Guid userId, Guid productId);
        Task<IPagedList<ResponseProductDto>> GetProducts(RequestProductsDto requestInfo);
        Task<DetailedProductDto> GetProductById(Guid productId);
    }
}
