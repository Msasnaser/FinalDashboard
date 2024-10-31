using feliciano.DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace feliciano.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var AdminRoleId = Guid.NewGuid().ToString();
            var UserRoleId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = AdminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = UserRoleId, Name = "User", NormalizedName = "USER" }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            var User = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Ali@gmail.com",
                NormalizedUserName = "ALI",
                Email = "Ali@gmail.com",
                NormalizedEmail = "ALI@GMAIL.COM",

                EmailConfirmed = true,
            };
            User.PasswordHash = hasher.HashPassword(User, "Ali@123");

            var Admin = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Ahmad@gmail.com",
                NormalizedUserName = "AHMAD",
                Email = "Ahmad@gmail.com",
                NormalizedEmail="AHMAD@GMAIL.COM",
                EmailConfirmed = true,
            };
            Admin.PasswordHash = hasher.HashPassword(Admin, "Ahmad@123");

            // Seed both users
            builder.Entity<ApplicationUser>().HasData(Admin, User);

            // Assign roles to both users
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = UserRoleId, UserId = User.Id },
                new IdentityUserRole<string> { RoleId = AdminRoleId, UserId = Admin.Id }
            );
        }



        public DbSet<Service> services { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Portfolio > portfolios { get; set; }
       public DbSet<Item> items {  get; set; } 
       public DbSet<Slider> sliders { get; set; }
    }
}
