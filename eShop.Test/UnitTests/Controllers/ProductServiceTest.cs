using AutoMapper;
using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.DTO.Product;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.Service;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System.Linq.Expressions;

namespace eShop.Test.UnitTests.Controllers
{
    public class ProductServiceTest
    {
        private readonly Mock<IGenericSearchService<Product>> _searchServiceMock;
        private readonly Mock<IGenericRepository<Product>> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMemoryCache> _cacheMock;
        private readonly ProductService _productService;

        public ProductServiceTest()
        {
            _searchServiceMock = new Mock<IGenericSearchService<Product>>();
            _repositoryMock = new Mock<IGenericRepository<Product>>();
            _mapperMock = new Mock<IMapper>();
            _cacheMock = new Mock<IMemoryCache>();

            _productService = new ProductService(
                _searchServiceMock.Object,
                _repositoryMock.Object,
                _mapperMock.Object,
                _cacheMock.Object
            );
        }

        [Fact]
        public async Task GetProductsByBrandAsync_ReturnsCorrectProducts()
        {
            // Arrange
            int brandId = 1;
            var productList = new List<Product>
            {
                new Product { Name = "P1", Brand = new Brand { Name = "Test1" }, Price = 1 },
                new Product { Name = "P2", Brand = new Brand { Name = "Test2" }, Price = 2 },
                new Product { Name = "P3", Brand = new Brand { Name = "Test3" } , Price = 3}
            };

            var expectedDtoList = new List<ProductDto>
            {
                new ProductDto { Id = 1, Name = "P1" },
                new ProductDto { Id = 3, Name = "P3" }
            };

            _repositoryMock.Setup(r => r.GetAllAsync(It.IsAny<Expression<Func<Product, object>>>()))
                           .ReturnsAsync(productList);

            _mapperMock.Setup(m => m.Map<IEnumerable<ProductDto>>(It.IsAny<IEnumerable<Product>>()))
                       .Returns(expectedDtoList);

            _cacheMock.Setup(c => c.Remove("all_products"));

            // Act
            var result = await _productService.GetProductsByBrandAsync(brandId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, p => p.Id == 1);
            Assert.Contains(result, p => p.Id == 3);
        }
    }
}
