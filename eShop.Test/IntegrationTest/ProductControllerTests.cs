using AutoMapper;
using eShop.API.Controllers;
using eShop.Repository.Data;
using eShop.Repository.Entities;
using eShop.Service.DTO.Product;
using eShop.Service.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace eShop.Test.IntegrationTest
{
    public class ProductControllerTests
    {
        private readonly ProductsController _controller;
        private readonly Mock<IProductService> _mockProductService;
        private readonly EShopDbContext _dbContext;
        private readonly Mock<IMapper> _mockMapper;

        public ProductControllerTests()
        {
            _mockProductService = new Mock<IProductService>();

            // Mocking IMapper
            _mockMapper = new Mock<IMapper>();

            // Setting up the in-memory database
            var services = new ServiceCollection();
            services.AddDbContext<EShopDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));
            services.AddSingleton(_mockProductService.Object);
            services.AddSingleton(_mockMapper.Object);  // Add the mock IMapper
            var serviceProvider = services.BuildServiceProvider();

            // Get the in-memory DbContext
            _dbContext = serviceProvider.GetRequiredService<EShopDbContext>();

            // Create controller
            _controller = new ProductsController(_mockProductService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByBrandIdAsync_ShouldReturnProductsForBrand()
        {
            // Arrange
            int brandId = 1;
            int subcategory = 1;

            // Add test data to in-memory DB
            _dbContext.Products.AddRange(new Product
            {
                Name = "Product 1",
                BrandId = brandId,
                SubCategoryId = subcategory,
                Price = 10
            },
            new Product
            {
                Name = "Product 2",
                BrandId = brandId,
                SubCategoryId = subcategory,
                Price = 20
            });

            await _dbContext.SaveChangesAsync();

            // Set up service to return the products from db
            List<ProductUpsertDto> products = new List<ProductUpsertDto>
            {
                new ProductUpsertDto { Name = "Product 1", BrandId = brandId, SubCategoryId = subcategory, Price = 10 },
                new ProductUpsertDto { Name = "Product 2", BrandId = brandId, SubCategoryId = subcategory, Price = 20 }
            };

            _mockProductService.Setup(service => service.GetProductsByBrandAsync(brandId))
                .ReturnsAsync(products);

            // Act
            IEnumerable<ProductUpsertDto> result = await _controller.GetByBrandIdAsync(brandId);

            // Assert
            List<ProductUpsertDto> okResult = Assert.IsType<List<ProductUpsertDto>>(result);
            Assert.Equal(2, okResult.Count);
        }

        [Fact]
        public async Task AddProduct_ShouldAddProductSuccessfully()
        {
            // Arrange
            ProductUpsertDto productDto = new()
            {
                Name = "New Product",
                BrandId = 1,
                SubCategoryId = 1,
                Price = 100
            };

            _mockProductService.Setup(service => service.AddAsync(productDto))
                .Returns(Task.CompletedTask);

            // Act
            IActionResult result = await _controller.AddProduct(productDto);

            // Assert
            CreatedAtActionResult createdResult = Assert.IsType<CreatedAtActionResult>(result);

            // Verify the product data
            Assert.Equal(productDto.Name, ((ProductUpsertDto)createdResult.Value).Name);
        }
    }
}
