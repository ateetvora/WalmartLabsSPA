using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WalmartLabs.Model;
using WalmartLabs.Model.ViewModel;
using Xunit;

namespace WalmartLabs.IntegrationTests.Controllers
{
    public class ProductControllerIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ProductControllerIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetProducts_WhenCalledWithValidSearchString_ReturnsResults()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/product/search/apple");

            string json;
            using (var content = response.Content)
            {
                json = await content.ReadAsStringAsync();
            }
            var res = JsonConvert.DeserializeObject<ProductsViewModel>(json);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(res.Products);
            Assert.NotEmpty(res.Products);
            Assert.IsAssignableFrom<ProductsViewModel>(res);
        }

        [Theory]
        [InlineData("236195635,632628379,955642724", 3)]
        [InlineData("55893549", 1)]
        public async Task GetProductDetails_WhenCalledWithValidProductIds_ReturnsExpectedResult(string productIds, int number)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/api/product/details?productIds={productIds}");

            string json;
            using (var content = response.Content)
            {
                json = await content.ReadAsStringAsync();
            }
            var res = JsonConvert.DeserializeObject<ProductDetailsViewModel>(json);

            //Assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(res.ProductDetailsList.Count(), number);
        }

        [Fact]
        public async Task GetGetProductRecommendations_WhenCalled_ReturnsProductsList()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/api/product/recommendations?productId=47826494");

            string json;
            using (var content = response.Content)
            {
                json = await content.ReadAsStringAsync();
            }
            var res = JsonConvert.DeserializeObject<ProductsViewModel>(json);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(res.Products);
            Assert.NotEmpty(res.Products);
            Assert.IsAssignableFrom<ProductsViewModel>(res);
        }
    }
}
