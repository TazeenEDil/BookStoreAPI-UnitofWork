using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Models;

namespace BookStoreAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasPrecision(18, 2);

            // Seed some categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "General" },
                new Category { Id = 2, Name = "Fiction" },
                new Category { Id = 3, Name = "Non-Fiction" },
                new Category { Id = 4, Name = "Science" },
                new Category { Id = 5, Name = "Technology" }
            );
        }
    }
}