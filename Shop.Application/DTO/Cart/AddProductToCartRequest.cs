using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO.Cart
{
    public class AddProductToCartRequest
    {
        public Guid ProductId { get; set; }
        public uint Quantity { get; set; }
    }
}
