using Microsoft.AspNetCore.Identity;
using Shop.Domain.Entities.Identity.Token;

namespace Shop.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual IList<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public virtual IList<Order> Orders { get; set; } = new List<Order>();
        public virtual IList<Product> Products { get; set; } = new List<Product>();
        public virtual IList<Cart> Carts { get; set; } = new List<Cart>();

    }
}
