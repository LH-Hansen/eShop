using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eShop.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    brand_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FK_subcategory_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    subcategory_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FK_category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.subcategory_id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_FK_category_id",
                        column: x => x.FK_category_id,
                        principalTable: "Categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<double>(type: "float", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: false),
                    FK_brand_id = table.Column<int>(type: "int", nullable: false),
                    FK_subcategory_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_FK_brand_id",
                        column: x => x.FK_brand_id,
                        principalTable: "Brands",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_FK_subcategory_id",
                        column: x => x.FK_subcategory_id,
                        principalTable: "SubCategories",
                        principalColumn: "subcategory_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    oder_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_order_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.oder_id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_FK_order_id",
                        column: x => x.FK_order_id,
                        principalTable: "Orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FK_product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_Review_Products_FK_product_id",
                        column: x => x.FK_product_id,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "brand_id", "description", "name" },
                values: new object[,]
                {
                    { 1, null, "Apple" },
                    { 2, null, "Samsung" },
                    { 3, null, "Sony" },
                    { 4, null, "LG" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "description", "name", "FK_subcategory_id" },
                values: new object[,]
                {
                    { 1, null, "Electronics", 0 },
                    { 2, null, "Home Appliances", 0 },
                    { 3, null, "Furniture", 0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "order_id", "orderdate", "TotalAmount" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2799.98 },
                    { 2, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 899.99000000000001 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "subcategory_id", "FK_category_id", "description", "name" },
                values: new object[,]
                {
                    { 1, 1, null, "Smartphones" },
                    { 2, 1, null, "Laptops" },
                    { 3, 1, null, "TVs" },
                    { 4, 2, null, "Refrigerators" },
                    { 5, 2, null, "Washing Machines" },
                    { 6, 3, null, "Sofas" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "product_id", "FK_brand_id", "description", "name", "price", "stock", "FK_subcategory_id" },
                values: new object[,]
                {
                    { 1, 1, null, "iPhone 14", 999.99000000000001, 50, 1 },
                    { 2, 2, null, "Samsung Galaxy S23", 899.99000000000001, 30, 1 },
                    { 3, 3, null, "Sony Bravia 55\" TV", 799.99000000000001, 20, 3 },
                    { 4, 4, null, "LG OLED 65\" TV", 1499.99, 15, 3 },
                    { 5, 1, null, "MacBook Pro 16\"", 2399.9899999999998, 10, 2 },
                    { 6, 2, null, "Samsung Galaxy Tab S8", 749.99000000000001, 25, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderLines",
                columns: new[] { "oder_id", "FK_order_id", "price", "product_id", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 999.99000000000001, 1, 1 },
                    { 2, 1, 2399.9899999999998, 5, 1 },
                    { 3, 2, 899.99000000000001, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_FK_order_id",
                table: "OrderLines",
                column: "FK_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_product_id",
                table: "OrderLines",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FK_brand_id",
                table: "Products",
                column: "FK_brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FK_subcategory_id",
                table: "Products",
                column: "FK_subcategory_id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_FK_product_id",
                table: "Review",
                column: "FK_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_FK_category_id",
                table: "SubCategories",
                column: "FK_category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
