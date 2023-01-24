using kaitoss.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kaitoss.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            this.SeedUsers(builder);
            base.OnModelCreating(builder);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            AppUser user = new AppUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                Email = "admin@gmail.com",
                FirstName = "Admin",
                LastName= "Admin",
                PhoneNumber = "1234567890"
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            passwordHasher.HashPassword(user, "Admin*123");

            builder.Entity<AppUser>().HasData(user);
        }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Settings> Settings { get; set; }
  
    }
  
}