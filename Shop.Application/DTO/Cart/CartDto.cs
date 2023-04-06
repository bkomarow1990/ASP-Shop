using Shop.Application.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO.Cart
{
    public class CartDto
    {
        public ResponseProductDto Product { get; set; }
        public uint Quantity { get; set; }
    }
}
