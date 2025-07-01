using BadgeTask.Models;
using Microsoft.EntityFrameworkCore;

namespace BadgeTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, PName = "Pen", Price = 34 },
                new Product { Id = 2, PName = "Pencil", Price = 23 },
                new Product { Id = 3, PName = "Ball", Price = 230 },
                new Product { Id = 4, PName = "Scale", Price = 5 },
                new Product { Id = 5, PName = "Bottle", Price = 423 });
        }
    }
}
