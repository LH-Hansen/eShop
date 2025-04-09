using eShop.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Repository.Data
{
    public class EShopDbContext(DbContextOptions<EShopDbContext> options) : DbContext(options)
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=eShop;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Apple" },
                new Brand { Id = 2, Name = "Samsung" },
                new Brand { Id = 3, Name = "Sony" },
                new Brand { Id = 4, Name = "LG" }
            );

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Home Appliances" },
                new Category { Id = 3, Name = "Furniture" }
            );

            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory { Id = 1, Name = "Smartphones", CategoryId = 1 },
                new SubCategory { Id = 2, Name = "Laptops", CategoryId = 1 },
                new SubCategory { Id = 3, Name = "TVs", CategoryId = 1 },
                new SubCategory { Id = 4, Name = "Refrigerators", CategoryId = 2 },
                new SubCategory { Id = 5, Name = "Washing Machines", CategoryId = 2 },
                new SubCategory { Id = 6, Name = "Sofas", CategoryId = 3 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 14", Price = 999.99, Stock = 50, BrandId = 1, SubCategoryId = 1 },
                new Product { Id = 2, Name = "Samsung Galaxy S23", Price = 899.99, Stock = 30, BrandId = 2, SubCategoryId = 1 },
                new Product { Id = 3, Name = "Sony Bravia 55\" TV", Price = 799.99, Stock = 20, BrandId = 3, SubCategoryId = 3 },
                new Product { Id = 4, Name = "LG OLED 65\" TV", Price = 1499.99, Stock = 15, BrandId = 4, SubCategoryId = 3 },
                new Product { Id = 5, Name = "MacBook Pro 16\"", Price = 2399.99, Stock = 10, BrandId = 1, SubCategoryId = 2 },
                new Product { Id = 6, Name = "Samsung Galaxy Tab S8", Price = 749.99, Stock = 25, BrandId = 2, SubCategoryId = 1 }
            );

            modelBuilder.Entity<OrderLine>().HasData(
                new OrderLine { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, Price = 999.99 },
                new OrderLine { Id = 2, OrderId = 1, ProductId = 5, Quantity = 1, Price = 2399.99 },
                new OrderLine { Id = 3, OrderId = 2, ProductId = 2, Quantity = 1, Price = 899.99 }
            );

            DateTime orderDate1 = new(2025, 3, 26);
            DateTime orderDate2 = new(2025, 3, 25);

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = orderDate1, TotalAmount = 2799.98 },
                new Order { Id = 2, OrderDate = orderDate2, TotalAmount = 899.99 }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    Title = "Great iPhone!",
                    Body = "This is the best iPhone I've ever owned. The performance is top-notch.",
                    ProductId = 1
                },
                new Review
                {
                    Id = 2,
                    Title = "Decent phone but battery could be better",
                    Body = "The phone is great overall, but I wish the battery lasted longer.",
                    ProductId = 2
                },
                new Review
                {
                    Id = 3,
                    Title = "Good TV, but sound quality lacking",
                    Body = "The picture quality is excellent, but the sound could use improvement.",
                    ProductId = 3
                },
                new Review
                {
                    Id = 4,
                    Title = "Amazing TV, worth the price",
                    Body = "The picture is stunning, and the price is justifiable for the quality.",
                    ProductId = 4
                }
            );
        }
    }
}
