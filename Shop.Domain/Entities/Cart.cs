using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Common;
using Shop.Domain.Entities.Identity;

namespace Shop.Domain.Entities
{
    public class Cart : ManyToManyBaseEntity
    {
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public uint Quantity { get; set; }
    }
}
