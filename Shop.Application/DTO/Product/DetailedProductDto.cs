using Shop.Application.DTO.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO.Product
{
    public class DetailedProductDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        public int StockQuantity { get; set; }
        public CategoryDto Category { get; set; }
    }
}
