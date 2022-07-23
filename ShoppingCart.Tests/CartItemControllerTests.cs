using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingCart.API.Controllers;
using ShoppingCart.Contracts.IServices;
using ShoppingCart.Entities.DTOs.CartItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CartItemControllerTests
    {
        private readonly CartItemController _sut;
        private readonly Mock<IServiceManager> _serviceManagerMock = new Mock<IServiceManager>();

        public CartItemControllerTests()
        {
            _sut = new CartItemController(_serviceManagerMock.Object);
        }

        [Fact]
        public async Task GetCartItemAsync_ShouldReturnOkResult_WhenItemExists()
        {
            // Arrange
            var cartId = It.IsAny<int>();
            var itemId = It.IsAny<int>();

            var item = new CartItemDto
            {
                CartId = cartId,
                CartItemId = itemId,
            };

            _serviceManagerMock.Setup(x => x.CartItemService.GetCartItemAsync(cartId, itemId, false)).ReturnsAsync(item);

            // Act
            var result = await _sut.GetCartItemAsync(cartId, itemId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetCartItemAsync_ShouldReturnNotFoundResult_WhenItemDoesNotExists()
        {
            // Arrange
            var cartId = It.IsAny<int>();
            var itemId = It.IsAny<int>();

            _serviceManagerMock.Setup(x => x.CartItemService.GetCartItemAsync(cartId, itemId, false)).ReturnsAsync(() => null);

            // Act
            var result = await _sut.GetCartItemAsync(cartId, itemId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddCartItemAsync_ShouldReturnBadRequest_WhenClientSendEmptyItem()
        {
            // Arrange
            var cartId = It.IsAny<int>();

            // Act
            var resutl = await _sut.AddCartItemAsync(null, cartId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resutl);
        }

        [Fact]
        public async Task AddCartItemAsync_ShouldReturnBadRequest_WhenClientSendInvalidObject()
        {
            // Arrange
            var cartId = It.IsAny<int>();
            var cartItemDto = new CartItemCreationDto
            {
                Description = "Item 1"
            };
            MockModelState(cartItemDto, _sut);

            // Act
            var resutl = await _sut.AddCartItemAsync(cartItemDto, cartId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resutl);
            Assert.False(_sut.ModelState.IsValid);
        }

        [Fact]
        public async Task AddCartItemAsync_ShouldReturnCreatedAtRouteResult_WhenItemWasSuccessfullyAdded()
        {
            // Arrange
            var cartId = It.IsAny<int>();
            var cartItemDto = new CartItemCreationDto
            {
                Name = "Item 1",
                Description = "Item 1",
                CreatedBy = "User test",
                Amount = 2
            };

            var cartItem = new CartItemDto
            {
                Name = "Item 1",
                Description = "Item 1",
                CreatedBy = "User test",
                Amount = 2,
                CartId = cartId,
                CartItemId = It.IsAny<int>(),
                TimeCreated = DateTime.Now,
                TimeUpdated = DateTime.Now
            };

            _serviceManagerMock.Setup(x => x.CartItemService.AddCartItemAsync(cartItemDto, cartId)).ReturnsAsync(cartItem);

            // Act
            var result = await _sut.AddCartItemAsync(cartItemDto, cartId);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async Task AddCartItemAsync_ShouldReturnNotFoundReponse_WhenItemWasNotAdded()
        {
            // Arrange
            var cartId = It.IsAny<int>();
            var item = new CartItemCreationDto
            {
                Name = "Test Item",
            };

            _serviceManagerMock.Setup(x => x.CartItemService.AddCartItemAsync(item, cartId)).ReturnsAsync(() => null);

            // Act
            var result = await _sut.AddCartItemAsync(item, cartId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task RemoveCartItemAsync_ShouldReturnNoContentResponse_Always()
        {
            // Arrange
            var cartId = It.IsAny<int>();
            var itemId = It.IsAny<int>();

            _serviceManagerMock.Setup(x => x.CartItemService.RemoveCartItemAsync(cartId, itemId));

            // Act
            var result = await _sut.RemoveCartItemAsync(cartId, itemId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        protected void MockModelState<TModel, TController>(TModel model, TController controller) where TController : ControllerBase
        {
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }
        }
    }
}
