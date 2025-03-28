using eShop.Repository.Entities;
using eShop.Service.Services.IService;
using Moq;

namespace eShop.Test.UnitTests.Brands
{
    public class BrandCRUDTest
    {
        private readonly Mock<IBrandService> _mockBrandService;

        public BrandCRUDTest()
        {
            _mockBrandService = new Mock<IBrandService>();
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            // Arrange
            List<Brand> brands =
            [
                new Brand { Id = 1, Name = "Brand 1" },
                new Brand { Id = 2, Name = "Brand 2" }
            ];

            _mockBrandService.Setup(service => service.GetAllAsync()).ReturnsAsync(brands);

            // Act
            IEnumerable<Brand> result = await _mockBrandService.Object.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Brand 1", result.First().Name);

        }

        [Fact]
        public async Task GetByIdAsyncTest()
        {
            // Arrange
            Brand brand = new() { Id = 1, Name = "Brand 1" };
            _mockBrandService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(brand);

            // Act
            Brand result = await _mockBrandService.Object.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Brand 1", result.Name);
        }

        [Fact]
        public async Task AddAsyncTest()
        {
            // Arrange
            Brand newBrand = new() { Id = 3, Name = "Brand 3" };
            _mockBrandService.Setup(service => service.AddAsync(It.IsAny<Brand>())).Returns(Task.CompletedTask);

            // Act
            await _mockBrandService.Object.AddAsync(newBrand);

            // Assert
            _mockBrandService.Verify(service => service.AddAsync(It.Is<Brand>(b => b.Name == "Brand 3")), Times.Once);
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            // Arrange
            Brand existingBrand = new() { Id = 1, Name = "Brand 1" };
            _mockBrandService.Setup(service => service.UpdateAsync(It.IsAny<Brand>())).Returns(Task.CompletedTask);

            // Act
            await _mockBrandService.Object.UpdateAsync(existingBrand);

            // Assert
            _mockBrandService.Verify(service => service.UpdateAsync(It.Is<Brand>(b => b.Id == 1 && b.Name == "Brand 1")), Times.Once);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            // Arrange
            int brandIdToDelete = 1;
            Brand brandToDelete = new() { Id = brandIdToDelete, Name = "Brand 1" };

            _mockBrandService.Setup(service => service.DeleteAsync(brandIdToDelete))
                             .Returns(Task.CompletedTask);

            // Act:
            await _mockBrandService.Object.DeleteAsync(brandIdToDelete);

            // Assert:

            Brand deletedBrand = await _mockBrandService.Object.GetByIdAsync(brandIdToDelete);

            Assert.Null(deletedBrand);
        }
    }
}
