using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.DTO.Product;

public class EditProductDto
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public Guid CategoryId { get; set; }
    public IFormFile Image { get; set; }
}