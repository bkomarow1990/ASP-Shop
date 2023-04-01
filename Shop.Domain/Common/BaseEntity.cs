using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Common
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateEdited { get; set; }
    }
    public class BaseEntity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
    }
}
