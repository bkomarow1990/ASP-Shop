using Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public ICollection<Category> Subcategories { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
