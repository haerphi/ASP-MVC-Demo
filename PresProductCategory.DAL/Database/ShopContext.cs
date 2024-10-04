using Microsoft.EntityFrameworkCore;
using PresProductCategory.DAL.Database.Configurations;
using PresProductCategory.DAL.Entities;

namespace PresProductCategory.DAL.Database
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductsCategories { get; set; } // Table intermédiaire de la ManyToMany avec propriété

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig()); // Table intermédiaire de la ManyToMany avec propriété
        }
    }
}
