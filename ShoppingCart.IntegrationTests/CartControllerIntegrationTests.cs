using FluentAssertions;
using Moq;
using ShoppingCart.Entities.Constants;
using ShoppingCart.Entities.DTOs.Cart;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCart.IntegrationTests
{
    public class CartControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public CartControllerIntegrationTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
            _client = _factory.CreateClient();
            _factory.UserRole = UserRoles.Standard;
        }

        [Fact]
        public async Task GetCartAsync_ShouldReturnCartDetailsAndOkResponse_WhenCartExists()
        {
            // Arrange
            var cartId = 1;

            // Act
            var response = await _client.GetAsync(ApiRoutes.Get.GetCartAsync(cartId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var cart = await response.Content.ReadFromJsonAsync<CartDto>();
            cart.Should().BeOfType<CartDto>();
            cart.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCartAsync_ShouldReturnNotFoundResult_WhenCartDoesNotExists()
        {
            // Arrange
            var cartId = 842039;

            // Act
            var response = await _client.GetAsync(ApiRoutes.Get.GetCartAsync(cartId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task GetCartAsync_ShouldHaveReadAccess_WhenUserHasViewerRole()
        {
            // Arrange
            var cartId = 1;
            _factory.UserRole = UserRoles.Viewer;

            // Act
            var response = await _client.GetAsync(ApiRoutes.Get.GetCartAsync(cartId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var cart = await response.Content.ReadFromJsonAsync<CartDto>();
            cart.Should().BeOfType<CartDto>();
            cart.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCartAsync_ShouldReturnForbiddenResult_WhenUserDoesNotHaveAppropriateRole()
        {
            // Arrange
            var cartId = It.IsAny<int>();
            _factory.UserRole = null;

            // Act
            var response = await _client.GetAsync(ApiRoutes.Get.GetCartAsync(cartId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        [Fact]
        public async Task CancelCartAsync_ShouldReturnNoContent_OnEveryAuthenticatedRequest()
        {
            // Arrange
            var cartId = It.IsAny<int>();

            // Act
            var response = await _client.PutAsync(ApiRoutes.Put.CancelCartAsync(cartId), null);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task CartControllerEndpoints_ShouldReturnForbiddenResult_WhenUserDoesNotHavePermissions()
        {
            // Arrange
            var cartId = It.IsAny<int>();
            _factory.UserRole = null;

            // Act
            var getCartResponse = await _client.GetAsync(ApiRoutes.Get.GetCartAsync(cartId));
            var cancelCartRepsonse = await _client.PutAsync(ApiRoutes.Put.CancelCartAsync(cartId), null);

            // Assert
            getCartResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
            cancelCartRepsonse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }


    }
}
