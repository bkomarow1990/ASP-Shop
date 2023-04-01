using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.Category;

namespace Shop.Application.DTO.Product
{
    public class ResponseProductDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public CategoryDto Category { get; set; }
    }
}
