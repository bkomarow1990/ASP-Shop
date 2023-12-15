using Shop.Application.DTO.QueryTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO.Product
{
    public class RequestProductsDto : PageInfo, IQueryObject
    {
        public Guid? Id { get; set; }
        public string ProductName { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public Guid? CategoryId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}
