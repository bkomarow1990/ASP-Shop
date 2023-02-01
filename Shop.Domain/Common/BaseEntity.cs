using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Common
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateEdit { get; set; }
    }
    public class BaseEntity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdit { get; set; }
    }
}
