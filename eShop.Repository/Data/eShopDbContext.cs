using eShop.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Repository.Data
{
    public class eShopDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }


        public eShopDbContext(DbContextOptions<eShopDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=eShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                        .HasMany(e => e.Categories)
                        .WithMany(e => e.Products)
                        .UsingEntity<CategoryProduct>();

            modelBuilder.Entity<Brand>()
                        .HasMany(b => b.Products)
                        .WithOne(p => p.Brand)
                        .HasForeignKey(p => p.Id);

            modelBuilder.Entity<CategoryProduct>()
                        .HasKey(t => new { t.CategoryId, t.ProductId });
        }
    }
}
