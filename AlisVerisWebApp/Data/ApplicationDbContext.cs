using AlisVerisWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AlisVerisWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AlisVerisWebApp.Models.Color> Color { get; set; } = default!;
        public DbSet<AlisVerisWebApp.Models.Size> Size { get; set; } = default!;

    }
}
