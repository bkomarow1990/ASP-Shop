using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Common
{
    public interface IManyToManyBaseEntity
    {
        DateTime DateCreated { get; set; }
        DateTime? DateEdited { get; set; }
    }
    public abstract class ManyToManyBaseEntity : IManyToManyBaseEntity
    {
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateEdited { get; set; }
    }
}
