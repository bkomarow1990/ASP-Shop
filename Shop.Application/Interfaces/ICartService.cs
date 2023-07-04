using Shop.Application.DTO.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.Product;

namespace Shop.Application.Interfaces
{
    public interface ICartService
    {
        Task<List<ResponseProductDto>> GetCartAsync(Guid userId, List<Guid> productIds);
    }
}
