using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingCart.API.Controllers;
using ShoppingCart.Contracts.IServices;
using ShoppingCart.Entities.DTOs.Cart;
using ShoppingCart.Entities.Models;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CartControllerTests
    {
        private readonly CartController _sut;
        private readonly Mock<IServiceManager> _serviceManagerMock = new Mock<IServiceManager>();
        public CartControllerTests()
        {
            _sut = new CartController(_serviceManagerMock.Object);
        }

        [Fact]
        public async Task GetCartAsync_ShouldReturnOk_WhenItemExists()
        {
            // Arrange
            var cartId = It.IsAny<int>();
            var cart = new CartDto
            {
                CartId = cartId,
                CreatedBy = "Test User",
                Status = CartStatus.Submited.ToString(),
            };

            _serviceManagerMock.Setup(x => x.CartService.GetCartAsync(cartId, false)).ReturnsAsync(cart);

            // Act
            var result = await _sut.GetCartAsync(cartId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetCartAsync_ShouldReturnNotFound_WhenCartDoesNotExists()
        {
            // Arrange
            var cartId = It.IsAny<int>();

            _serviceManagerMock.Setup(x => x.CartService.GetCartAsync(cartId, false)).ReturnsAsync(() => null);

            // Act
            var result = await _sut.GetCartAsync(cartId); 

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CancelCartAsync_ShouldReturnNoContentResult_EveryTime()
        {
            // Arrange
            var cartId = It.IsAny<int>();

            _serviceManagerMock.Setup(x => x.CartService.CancelCartAsync(cartId));

            // Act
            var result = await _sut.CancelCartAsync(cartId);

            // Assert
            _serviceManagerMock.Verify(v => v.CartService.CancelCartAsync(cartId), Times.Once);
            Assert.IsType<NoContentResult>(result);
        }
    }
}
