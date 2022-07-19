using AutoMapper;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Contracts.IServices;
using ShoppingCart.Entities.DTOs.CartItem;

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

        public async Task<CartItemDto?> GetCartItemAsync(int cartId, int itemId, bool trackChanges)
        {
            var cartItem = await repositoryManager.CartItems.GetCartItemAsync(cartId, itemId, trackChanges);

            var cartItemDto = mapper.Map<CartItemDto>(cartItem);

            return cartItemDto;
        }
    }
}
