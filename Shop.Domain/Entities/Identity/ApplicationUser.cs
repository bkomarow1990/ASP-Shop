using Microsoft.AspNetCore.Identity;
using Shop.Domain.Entities.Identity.Token;

namespace Shop.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual IList<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
