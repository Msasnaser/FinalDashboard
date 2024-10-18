using feliciano.DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace feliciano.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Service> services { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Portfolio > portfolios { get; set; }
       public DbSet<Item> items {  get; set; } 
       public DbSet<Slider> sliders { get; set; }
    }
}
