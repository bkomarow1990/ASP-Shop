using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Entities.Identity;
using Shop.Domain.Entities.Identity.Token;
using System.Text.Json;

namespace Shop.Infrastructure.Data
{
    public class ShopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ShopDbContext(DbContextOptions options)
        : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Category
            builder.Entity<Category>().HasData(
                JsonSerializer.Deserialize<List<Category>>(File.ReadAllText("categoriesSeeder.json"))
            );
            builder.Entity<Category>().HasOne(c => c.ParentCategory).WithMany(c => c.Subcategories).HasForeignKey(c => c.ParentCategoryId);
            #endregion
            #region Product
            builder.Entity<Product>()
                .HasOne(p => p.User)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.UserId);
            #endregion
            #region Order
            //builder.Entity<Order>().Has
            #endregion
            #region OrderItem

            builder.Entity<OrderItem>().HasKey(o => new { o.OrderId, o.ProductId});
            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict)
                ;
            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
                ;
                #endregion
            base.OnModelCreating(builder);
        }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
