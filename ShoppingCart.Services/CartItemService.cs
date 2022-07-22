using AutoMapper;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Contracts.IServices;
using ShoppingCart.Entities.DTOs.CartItem;
using ShoppingCart.Entities.Models;

namespace ShoppingCart.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public CartItemService(IRepositoryManager manager, IMapper autoMapper)
        {
            repositoryManager = manager;
            mapper = autoMapper;
        }

        public async Task<CartItemDto?> AddCartItemAsync(CartItemCreationDto cartItemDto, int cartId)
        {
            var cart = await repositoryManager.Carts.GetCartAsync(cartId, false);
            if (cart == null)
            {
                return null;
            }

            var cartItem = mapper.Map<CartItem>(cartItemDto);
            cartItem.CartId = cartId;
            cartItem.TimeCreated = DateTime.Now;
            cartItem.TimeUpdated = DateTime.Now;

            await repositoryManager.CartItems.CreateAsync(cartItem);
            await repositoryManager.SaveAsync();

            var cartItemDtoResult = mapper.Map<CartItemDto>(cartItem);

            return cartItemDtoResult;
        }

        public async Task<CartItemDto?> GetCartItemAsync(int cartId, int itemId, bool trackChanges)
        {
            var cartItem = await repositoryManager.CartItems.GetCartItemAsync(cartId, itemId, trackChanges);

            if(cartItem == null)
            {
                return null;
            }

            var cartItemDto = mapper.Map<CartItemDto>(cartItem);

            return cartItemDto;
        }

        public async Task RemoveCartItemAsync(int cartId, int itemId)
        {
            var item = await repositoryManager.CartItems.GetCartItemAsync(cartId, itemId, true);
            if (item != null)
            {
                repositoryManager.CartItems.Delete(item);
                await repositoryManager.SaveAsync();
            }
        }
    }
}
