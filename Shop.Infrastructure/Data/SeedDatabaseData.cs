using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Entities.Identity;

namespace Shop.Infrastructure.Data
{
    public static class SeedDatabaseData
    {
        public static async void SeedDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices
                       .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
                await context.Database.MigrateAsync();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                if (!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new ApplicationRole()
                    {
                        Name = "Administrator"
                    });
                    await roleManager.CreateAsync(new ApplicationRole()
                    {
                        Name = "Seller"
                    });

                    await roleManager.CreateAsync(new ApplicationRole()
                    {
                        Name = "User"
                    });
                }

                if (!userManager.Users.Any())
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "admin",
                        Email = "admin@gmail.com",
                        EmailConfirmed = true,
                    };

                    await userManager.CreateAsync(user, "SuperSexMegaBombaAdminPassword2023");

                    await userManager.AddToRoleAsync(user, "Administrator");
                    await userManager.AddToRoleAsync(user, "User");


                    var userSeller = new ApplicationUser()
                    {
                        UserName = "Seller",
                        Email = "seller@gmail.com",
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(userSeller, "SuperSexMegaBombaAdminPassword2023");

                    await userManager.AddToRoleAsync(userSeller, "Seller");
                    await userManager.AddToRoleAsync(userSeller, "User");
                }
            }
        }
    }
}
