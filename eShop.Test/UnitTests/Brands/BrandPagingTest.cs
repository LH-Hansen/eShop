using eShop.Repository.Entities;
using eShop.Service.DTO;
using eShop.Service.Services.IService;
using FluentAssertions;
using Moq;

namespace eShop.Test.UnitTests.Brands
{
    public class BrandPagingTest
    {
        private readonly Mock<IBrandService> _mockBrandService;

        public BrandPagingTest()
        {
            _mockBrandService = new Mock<IBrandService>();
        }

        [Fact]
        public async Task GetPaginatedBrandsTest()
        {
            // Arrange
            int page = 2;
            int pageSize = 5;
            string? searchTerm = null;

            List<Brand> allBrands =
            [

                new() { Id = 0, Name = "Brand 0" },
                new() { Id = 1, Name = "Brand 1" },
                new() { Id = 2, Name = "Brand 2" },
                new() { Id = 3, Name = "Brand 3" },
                new() { Id = 4, Name = "Brand 4" },
                new() { Id = 5, Name = "Brand 5" },
                new() { Id = 6, Name = "Brand 6" },
                new() { Id = 7, Name = "Brand 7" },
                new() { Id = 8, Name = "Brand 8" },
                new() { Id = 9, Name = "Brand 9" },
                new() { Id = 10, Name = "Brand 10" }
            ];

            _mockBrandService.Setup(service => service.GetPaginatedSearchAsync(page, pageSize, searchTerm));

            // Act
            IEnumerable<BrandDto> brands = await _mockBrandService.Object.GetPaginatedSearchAsync(page, pageSize, searchTerm);

            /// Assert
            brands.Should().HaveCount(pageSize);
            brands.First().Id.Should().Be(5);
            brands.Last().Id.Should().Be(9);
        }
    }
}