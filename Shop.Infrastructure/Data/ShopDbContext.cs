using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Identity;
using Shop.Domain.Entities.Identity.Token;

namespace Shop.Infrastructure.Data
{
    public class ShopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ShopDbContext(DbContextOptions options)
        : base(options)
        {
            
        }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
