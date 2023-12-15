using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO.Common
{
    public interface IPaginationRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
