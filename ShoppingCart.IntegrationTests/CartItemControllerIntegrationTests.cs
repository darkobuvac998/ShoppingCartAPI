using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using ShoppingCart.Entities.DTOs.CartItem;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCart.IntegrationTests
{
    public class CartItemControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public CartItemControllerIntegrationTests()
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
            returnedCartItem.Should().BeOfType<CartItemDto>();
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

        [Fact]
        public async Task GetCartItemAsync_ShouldReturnNotFoundResponse_WhenItemDoesNotExistsInDatabse()
        {
            // Arrange
            var cartId = 4829;
            var itemId = 34209;

            // Act
            var response = await _client.GetAsync(ApiRoutes.Get.GetCartItemAsync(cartId, itemId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetCartItemAsync_ShouldReturnOkReponseAndItem_WhenItemExistsAndUserHasViewerRole()
        {
            // Arrange
            var cartId = 1;
            var itemId = 1;
            _factory.UserRole = "Viewer";

            // Act
            var response = await _client.GetAsync(ApiRoutes.Get.GetCartItemAsync(cartId, itemId));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedCartItem = await response.Content.ReadFromJsonAsync<CartItemDto>();
            returnedCartItem.Should().NotBeNull();
        }

        [Fact]
        public async Task AddCartItemAsync_ShouldReturnUnsuportedMediaType_WhenItemIsNull()
        {
            // Arrange
            var cartId = It.IsAny<int>();

            // Act
            var response = await _client.PostAsync(ApiRoutes.Post.AddCartItemAsync(cartId), null);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.UnsupportedMediaType);

        }

        [Fact]
        public async Task AddCartItemAsync_ShouldReturnBadRequest_WhenDtoIsNotValid()
        {
            // Arrange
            var cartId = It.IsAny<int>();
            var cartItemCreationDto = new CartItemCreationDto
            {
                Name = "Test name"
            };

            var data = CreatePostRequesContent(cartItemCreationDto);

            // Act
            var response = await _client.PostAsync(ApiRoutes.Post.AddCartItemAsync(cartId), data);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task AddCartItemAsync_ShouldReturnCreatedResponseAndCartItemDto_WhenAddingIsSuccessfull()
        {
            // Arrange
            var cartId = 1;
            var cartItemCreationDto = new CartItemCreationDto
            {
                Name = "Integration test item",
                Amount = 2,
                CreatedBy = "Integration test user",
                Description = "Created in integration test"
            };

            var data = CreatePostRequesContent(cartItemCreationDto);

            // Act
            var response = await _client.PostAsync(ApiRoutes.Post.AddCartItemAsync(cartId), data);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var returnedCartItem = await response.Content.ReadFromJsonAsync<CartItemDto>();
            returnedCartItem.CartId.Should().Be(cartId);
            returnedCartItem.Should().NotBeNull();
            returnedCartItem.Should().BeOfType<CartItemDto>();
            returnedCartItem.Should().BeEquivalentTo(cartItemCreationDto, options => options.ComparingByValue<CartItemDto>().ExcludingMissingMembers());
            returnedCartItem.TimeCreated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public async Task AddCartItemAsync_ShouldReturnNotFoundResult_WhenCartDoesNotExists()
        {

        }

        private StringContent CreatePostRequesContent(object? data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
