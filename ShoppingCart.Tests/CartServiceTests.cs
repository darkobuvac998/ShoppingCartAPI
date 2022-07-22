using AutoMapper;
using Moq;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Entities.DTOs.Cart;
using ShoppingCart.Entities.Models;
using ShoppingCart.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CartServiceTests
    {
        private readonly CartService _sut;
        private readonly Mock<IRepositoryManager> _repoManagerMock = new Mock<IRepositoryManager>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public CartServiceTests()
        {
            _sut = new CartService(_repoManagerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetCartAsync_ShouldReturnCart_WhenCartExists()
        {
            // Arrange
            var cartId = 1;
            var cart = new Cart
            {
                CartId = cartId,
                Status = CartStatus.Draft,
                TimeCreated = DateTime.Now,
                TimeUpdated = DateTime.Now,
                CreatedBy = "UserTest",
                CartItems = new List<CartItem>
                {
                    new CartItem
                    {
                        CartId = cartId,
                        CartItemId = 1,
                        Amount = 2,
                        CreatedBy = "UserTest",
                        Name = "Item 1",
                        Description = "Desc 1",
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                    }
                }
            };
            var cartDto = new CartDto
            {
                CartId = cartId,
                Status = "Draft",
                TimeCreated = DateTime.Now,
                TimeUpdated = DateTime.Now,
                CreatedBy = "UserTest",
                CartItems = new List<CartItemShortDto>
                {
                    new CartItemShortDto
                    {
                        Name = "Item 1",
                        CartItemId = 1
                    }
                }
            };

            _repoManagerMock.Setup(x => x.Carts.GetCartAsync(cartId, false)).ReturnsAsync(cart);
            _mapperMock.Setup(x => x.Map<CartDto>(It.IsAny<Cart>())).Returns(cartDto);

            // Act
            var result = await _sut.GetCartAsync(cartId, false);

            // Assert
            Assert.Equal(cartDto, result);
        }

        [Fact]
        public async Task GetCartAsync_ShouldReturnNothing_WhenCartNotExists()
        {
            // Arrange
            var cartId = 1;
            _repoManagerMock.Setup(x => x.Carts.GetCartAsync(cartId, false)).ReturnsAsync(() => null);

            // Act
            var result = await _sut.GetCartAsync(cartId, false);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CancelCartAsync_ShouldChangeStatusToCancelled_WhenCartExists()
        {
            // Arrange
            var cartId = 1;
            var cart = new Cart
            {
                CartId = cartId,
                Status = CartStatus.Draft,
                TimeCreated = DateTime.Now,
                TimeUpdated = DateTime.Now,
                CreatedBy = "UserTest",
                CartItems = new List<CartItem>
                {
                    new CartItem
                    {
                        CartId = cartId,
                        CartItemId = 1,
                        Amount = 2,
                        CreatedBy = "UserTest",
                        Name = "Item 1",
                        Description = "Desc 1",
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                    }
                }
            };

            _repoManagerMock.Setup(x => x.Carts.GetCartAsync(cartId, true)).ReturnsAsync(cart);

            // Act
            await _sut.CancelCartAsync(cartId);

            // Assert
            _repoManagerMock.Verify(v => v.Carts.Update(cart), Times.Once);
            _repoManagerMock.Verify(v => v.SaveAsync(), Times.Once);
            Assert.Equal(CartStatus.Cancelled, cart.Status);
            Assert.Equal(DateTime.Now.ToString("HH:mm:ss"), cart.TimeUpdated.ToString("HH:mm:ss"));

        }

        [Fact]
        public async Task CancelCartAsync_ShouldNotCallSaveChanges_WhenCartDoesNotExists()
        {
            // Arrange
            var cartId = 1;
            var itemId = 1;

            _repoManagerMock.Setup(x => x.Carts.GetCartAsync(cartId, true)).ReturnsAsync(() => null);

            // Act
            await _sut.CancelCartAsync(cartId);

            // Assert
            _repoManagerMock.Verify(v => v.SaveAsync(), Times.Never);
        }
    }
}