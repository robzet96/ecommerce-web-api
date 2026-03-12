using ecommerce_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_web_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
