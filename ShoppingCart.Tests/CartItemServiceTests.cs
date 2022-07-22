using AutoMapper;
using Moq;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Entities.DTOs.CartItem;
using ShoppingCart.Entities.Models;
using ShoppingCart.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CartItemServiceTests
    {
        private readonly CartItemService _sut;
        private readonly Mock<IRepositoryManager> _repoManagerMock = new Mock<IRepositoryManager>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public CartItemServiceTests()
        {
            _sut = new CartItemService(_repoManagerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task AddCartItemAsync_ShouldReturnCreatedCartItem_WhenCartExists()
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
            };
            var cartItemDto = new CartItemCreationDto
            {
                Amount = 2,
                CreatedBy = "Test User",
                Description = "Desc 1",
                Name = "Item 1"
            };

            var cartItem = new CartItem
            {
                Amount = 2,
                CreatedBy = "Test User",
                Description = "Desc 1",
                Name = "Item 1"
            };

            var cartItemDtoResult = new CartItemDto
            {
                Amount = 2,
                CreatedBy = "Test User",
                Description = "Desc 1",
                Name = "Item 1",
                CartId = cartId,
                CartItemId = 1,
                TimeCreated = DateTime.Now,
                TimeUpdated = DateTime.Now
            };

            _repoManagerMock.Setup(x => x.Carts.GetCartAsync(cartId, false)).ReturnsAsync(cart);
            _mapperMock.Setup(x => x.Map<CartItem>(It.IsAny<CartItemCreationDto>())).Returns(cartItem);
            _repoManagerMock.Setup(x => x.CartItems.CreateAsync(cartItem)).Returns(Task.FromResult(cartItem));
            _repoManagerMock.Setup(x => x.SaveAsync()).Returns(Task.FromResult(0));
            _mapperMock.Setup(x => x.Map<CartItemDto>(It.IsAny<CartItem>())).Returns(cartItemDtoResult);

            // Act
            var result = await _sut.AddCartItemAsync(cartItemDto, cartId);

            // Assert
            Assert.Equal(cartId, cartItem.CartId);
            Assert.Equal(DateTime.Now.ToString("HH:mm:ss"), cartItem.TimeCreated.ToString("HH:mm:ss"));
            Assert.Equal(DateTime.Now.ToString("HH:mm:ss"), cartItem.TimeUpdated.ToString("HH:mm:ss"));
            Assert.Equal(cartItemDtoResult, result);
            _repoManagerMock.Verify(v => v.CartItems.CreateAsync(cartItem), Times.Once);
            _repoManagerMock.Verify(v => v.SaveAsync(), Times.Once);

        }

        [Fact]
        public async Task AddCartItemAsync_ShouldReturnNothing_WhenCartDoesNotExists()
        {
            // Arrange
            var cartId = 1;
            var cartItemDto = new CartItemCreationDto
            {
                Amount = 2,
                CreatedBy = "Test User",
                Description = "Desc 1",
                Name = "Item 1"
            };

            _repoManagerMock.Setup(x => x.Carts.GetCartAsync(cartId, false)).ReturnsAsync(() => null);

            // Act
            var result = await _sut.AddCartItemAsync(cartItemDto, cartId);

            // Assert
            Assert.Null(result);

        }

        [Fact]
        public async Task AddCartItemAsync_ShouldNotCallSaveAsync_WhenCartDoesNotExists()
        {
            // Arrange
            var cartId = 1;
            var cartItemDto = new CartItemCreationDto
            {
                Amount = 2,
                CreatedBy = "Test User",
                Description = "Desc 1",
                Name = "Item 1"
            };

            _repoManagerMock.Setup(x => x.Carts.GetCartAsync(cartId, false)).ReturnsAsync(() => null);

            // Act
            await _sut.AddCartItemAsync(cartItemDto, cartId);

            // Assert
            _repoManagerMock.Verify(v => v.SaveAsync(), Times.Never);

        }

        [Fact]
        public async Task GetCartItemAsync_ShouldReturnCartItemDto_WhenItemExists()
        {
            // Arrange
            var cartId = 1;
            var cartItemId = 1;

            var item = new CartItem
            {
                Amount = 2,
                CartId = cartId,
                CartItemId = cartItemId,
                CreatedBy = "Test User",
                Description = "Desc 1",
                Name = "Item 1|1",
                TimeCreated = DateTime.Now,
                TimeUpdated = DateTime.Now,
            };

            var itemDto = new CartItemDto
            {
                Amount = 2,
                CartId = cartId,
                CartItemId = cartItemId,
                CreatedBy = "Test User",
                Description = "Desc 1",
                Name = "Item 1|1",
                TimeCreated = DateTime.Now,
                TimeUpdated = DateTime.Now,
            };

            _repoManagerMock.Setup(x => x.CartItems.GetCartItemAsync(cartId, cartItemId, false)).ReturnsAsync(item);
            _mapperMock.Setup(x => x.Map<CartItemDto>(It.IsAny<CartItem>())).Returns(itemDto);

            // Act
            var result = await _sut.GetCartItemAsync(cartId, cartItemId, false);

            // Assert
            Assert.Equal(itemDto, result);

        }

        [Fact]
        public async Task GetCartItemAsync_ShouldReturnNothing_WhenItemDoesNotExists()
        {
            // Arrange
            var cartId = 1;
            var cartItemId = 1;

            _repoManagerMock.Setup(x => x.CartItems.GetCartItemAsync(cartId, cartItemId, false)).ReturnsAsync(() => null);

            // Act
            var result = await _sut.GetCartItemAsync(cartId, cartItemId, false);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task RemoveCartItemAsync_ShouldRemoveAndCallSaveChanges_WhenItemExists()
        {
            // Arrange
            var cartId = 1;
            var itemId = 1;

            var item = new CartItem
            {
                Amount = 2,
                CartId = cartId,
                CartItemId = itemId,
                CreatedBy = "Test User",
                Description = "Desc 1",
                Name = "Item 1|1",
                TimeCreated = DateTime.Now,
                TimeUpdated = DateTime.Now,
            };

            _repoManagerMock.Setup(x => x.CartItems.GetCartItemAsync(cartId, itemId, true)).ReturnsAsync(() => item);

            // Act
            await _sut.RemoveCartItemAsync(cartId, itemId);

            // Assert
            _repoManagerMock.Verify(v => v.CartItems.Delete(item), Times.Once);
            _repoManagerMock.Verify(v => v.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task RemoveCartItemAsync_ShouldNotCallSaveChanges_WhenItemDoesNotExists()
        {
            // Arrange
            var cartId = 1;
            var itemId = 1;

            _repoManagerMock.Setup(x => x.CartItems.GetCartItemAsync(cartId, itemId, true)).ReturnsAsync(() => null);

            // Act
            await _sut.RemoveCartItemAsync(cartId, itemId);

            // Assert
            _repoManagerMock.Verify(v => v.SaveAsync(), Times.Never);
        }
    }
}
