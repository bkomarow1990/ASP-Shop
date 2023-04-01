using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO.Category
{
    public class CategoryWithSubCategoriesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CategoryDto> Subcategories { get; set; }
    }
}
