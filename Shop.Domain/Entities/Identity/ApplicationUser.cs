using Microsoft.AspNetCore.Identity;
using Shop.Domain.Entities.Identity.Token;

namespace Shop.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual IList<RefreshToken> RefreshTokens { get; set; }
    }
}
