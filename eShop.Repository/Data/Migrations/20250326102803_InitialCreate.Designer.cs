﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eShop.Repository.Data;

#nullable disable

namespace eShop.Repository.Data.Migrations
{
    [DbContext(typeof(EShopDbContext))]
    [Migration("20250326102803_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eShop.Repository.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("brand_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sony"
                        },
                        new
                        {
                            Id = 4,
                            Name = "LG"
                        });
                });

            modelBuilder.Entity("eShop.Repository.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("FK_subcategory_id");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronics",
                            SubCategoryId = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Home Appliances",
                            SubCategoryId = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Furniture",
                            SubCategoryId = 0
                        });
                });

            modelBuilder.Entity("eShop.Repository.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("orderdate");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderDate = new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalAmount = 2799.98
                        },
                        new
                        {
                            Id = 2,
                            OrderDate = new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalAmount = 899.99000000000001
                        });
                });

            modelBuilder.Entity("eShop.Repository.Entities.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("oder_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("FK_order_id");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            Price = 999.99000000000001,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            Price = 2399.9899999999998,
                            ProductId = 5,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2,
                            Price = 899.99000000000001,
                            ProductId = 2,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("eShop.Repository.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("FK_brand_id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("FK_subcategory_id");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Name = "iPhone 14",
                            Price = 999.99000000000001,
                            Stock = 50,
                            SubCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            Name = "Samsung Galaxy S23",
                            Price = 899.99000000000001,
                            Stock = 30,
                            SubCategoryId = 1
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            Name = "Sony Bravia 55\" TV",
                            Price = 799.99000000000001,
                            Stock = 20,
                            SubCategoryId = 3
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 4,
                            Name = "LG OLED 65\" TV",
                            Price = 1499.99,
                            Stock = 15,
                            SubCategoryId = 3
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 1,
                            Name = "MacBook Pro 16\"",
                            Price = 2399.9899999999998,
                            Stock = 10,
                            SubCategoryId = 2
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 2,
                            Name = "Samsung Galaxy Tab S8",
                            Price = 749.99000000000001,
                            Stock = 25,
                            SubCategoryId = 1
                        });
                });

            modelBuilder.Entity("eShop.Repository.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("review_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("body");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("FK_product_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("eShop.Repository.Entities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subcategory_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("FK_category_id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Smartphones"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Laptops"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "TVs"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "Refrigerators"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Name = "Washing Machines"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Name = "Sofas"
                        });
                });

            modelBuilder.Entity("eShop.Repository.Entities.OrderLine", b =>
                {
                    b.HasOne("eShop.Repository.Entities.Order", "Order")
                        .WithMany("OrderLine")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.Repository.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("eShop.Repository.Entities.Product", b =>
                {
                    b.HasOne("eShop.Repository.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.Repository.Entities.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("eShop.Repository.Entities.Review", b =>
                {
                    b.HasOne("eShop.Repository.Entities.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("eShop.Repository.Entities.SubCategory", b =>
                {
                    b.HasOne("eShop.Repository.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("eShop.Repository.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("eShop.Repository.Entities.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("eShop.Repository.Entities.Order", b =>
                {
                    b.Navigation("OrderLine");
                });

            modelBuilder.Entity("eShop.Repository.Entities.Product", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("eShop.Repository.Entities.SubCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
