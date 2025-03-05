using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor that takes DbContextOptions and passes it to the base DbContext class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet property for Categories and product, representing the Categories and Products table in the database
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // Method to configure the model using the ModelBuilder API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configures the relationship between the Category and Product entities
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
