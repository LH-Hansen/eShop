using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Json;

namespace eShop.Test.IntegrationTest
{
    public class ProductControllerTest
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;

        public ProductsControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()); // Assuming you have a Startup class in your API
            _client = _server.CreateClient(); // Create the HttpClient that will make the requests
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnOk()
        {
            // Arrange
            var response = await _client.GetAsync("/rest/v1/products");

            // Assert
            response.EnsureSuccessStatusCode(); // Assert the HTTP response code is 200
            var products = await response.Content.ReadAsStringAsync();
            Assert.Contains("Product", products); // Example check to ensure some products exist
        }

        [Fact]
        public async Task GetProductById_ShouldReturnOk()
        {
            // Arrange
            var productId = 1; // assuming a product with id 1 exists in your system
            var response = await _client.GetAsync($"/rest/v1/products/{productId}");

            // Assert
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsStringAsync();
            Assert.Contains("ProductName", product); // Example check for content
        }

        [Fact]
        public async Task AddProduct_ShouldReturnCreated()
        {
            // Arrange
            var productDto = new
            {
                Name = "New Product",
                Description = "Product Description",
                Price = 100.0,
                BrandId = 1,
                CategoryId = 2
            };

            var response = await _client.PostAsJsonAsync("/rest/v1/products", productDto);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(201, (int)response.StatusCode); // Assert that the status code is 201 (Created)
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnNoContent()
        {
            // Arrange
            var productId = 1; // assuming a product with id 1 exists
            var response = await _client.DeleteAsync($"/rest/v1/products/{productId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(204, (int)response.StatusCode); // Assert that the status code is 204 (No Content)
        }
    }
}
