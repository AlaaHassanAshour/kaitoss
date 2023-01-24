using kaitoss.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace kaitoss.Data.Data.SeedData
{
    public static class SeedUser
    {
        public static async Task SeedSuperAdminAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var defaultUser = new AppUser
                {

                    Email = "Admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "superadmin@gmail.com"
                };
                if (userManager.Users.All(u => u.Id != defaultUser.Id))
                {
                    var user = await userManager.FindByEmailAsync(defaultUser.Email);
                    if (user == null)
                    {
                        await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                        await userManager.AddToRoleAsync(defaultUser, "Admin");
                    }
                }
            }
        }
    }
}