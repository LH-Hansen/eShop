using AutoMapper;
using eShop.API.Controllers;
using eShop.Service.DTO.Product;
using eShop.Service.Services.Service;
using Moq;

namespace eShop.Test.UnitTests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ProductsController _controller;

        public ProductControllerTests()
        {
            _mockProductService = new Mock<IProductService>();
            _mockMapper = new Mock<IMapper>();

            _controller = new ProductsController(_mockProductService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByBrandIdAsync_ShouldReturnMappedProductUpsertDtos()
        {
            // Arrange
            int brandId = 1;
            int subCategoryId = 1;

            List<ProductUpsertDto> productDtos = new List<ProductUpsertDto>
                {
                    new ProductUpsertDto { Name = "Product 1", BrandId = brandId, SubCategoryId = subCategoryId, Price = 10 },
                    new ProductUpsertDto { Name = "Product 2", BrandId = brandId, SubCategoryId = subCategoryId, Price = 10 }
                };

            _mockProductService.Setup(service => service.GetProductsByBrandAsync(brandId))
                .ReturnsAsync(productDtos);

            List<ProductUpsertDto> productUpsertDtos = new List<ProductUpsertDto>
            {
                new ProductUpsertDto { Name = "Product 1", BrandId = brandId, SubCategoryId = subCategoryId},
                new ProductUpsertDto { Name = "Product 2", BrandId = brandId, SubCategoryId = subCategoryId}
            };

            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<ProductUpsertDto>>(productDtos))
                .Returns(productUpsertDtos);

            // Act
            var result = await _controller.GetByBrandIdAsync(brandId);

            // Assert
            var okResult = Assert.IsType<List<ProductUpsertDto>>(result);
            Assert.Equal(productUpsertDtos.Count, okResult.Count);
        }
    }
}
