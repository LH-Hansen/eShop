using System.Net;

namespace eShop.Test.IntegrationTest
{
    public class ProductControllerTest
    {
        private readonly HttpClient _client;

        public ProductControllerTest()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44394") // 👈 Your running API base URI
            };
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnSuccess()
        {
            // Hit the actual endpoint, NOT the Swagger page
            var response = await _client.GetAsync("/rest/v1/products");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
