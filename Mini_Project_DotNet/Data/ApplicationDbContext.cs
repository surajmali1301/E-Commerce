using Microsoft.EntityFrameworkCore;
using Mini_Project_DotNet.Models;

namespace Mini_Project_DotNet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Orders> Orders { get; set; }
    }
}
