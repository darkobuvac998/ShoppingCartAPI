using FluentAssertions;
using Moq;
using ShoppingCart.Entities.DTOs.CartItem;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCart.IntegrationTests
{
    public class CartItemControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public CartItemControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
            _factory.UserRole = "Standard";
            _client = _factory.CreateClient();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        }

        [Fact]
        public async Task GetCartItemAsync_ShouldReturnSingleItemAndOkResponse_WhenItemExistsInDatabse()
        {
            // Arrange
            var cartId = 1;
            var itemId = 1;

            // Act  
            var response = await _client.GetAsync(ApiRoutes.Get.GetCartItemAsync(cartId, itemId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedCartItem = await response.Content.ReadFromJsonAsync<CartItemDto>();
            returnedCartItem.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCartItemAsync_ShouldReturnForbiddenResponse_WhenUserIsNotStandardOrViewer()
        {
            // Arrange
            var cartId = It.IsAny<int>();
            var itemId = It.IsAny<int>();
            _factory.UserRole = "Anonymous";

            // Act
            var response = await _client.GetAsync(ApiRoutes.Get.GetCartItemAsync(cartId, itemId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}
