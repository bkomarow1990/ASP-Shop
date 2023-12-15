using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.Common;

namespace Shop.Application.DTO.User.Admin
{
    public class GetUsersRequest : IPaginationRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
