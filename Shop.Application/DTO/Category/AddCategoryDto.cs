using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO.Category
{
    public class AddCategoryDto
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}
