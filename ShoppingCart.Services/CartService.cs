using AutoMapper;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Contracts.IServices;
using ShoppingCart.Entities.DTOs.Cart;
using ShoppingCart.Entities.Models;

namespace ShoppingCart.Services
{
    public class CartService : ICartService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public CartService(IRepositoryManager manager, IMapper autoMapper)
        {
            repositoryManager = manager;
            mapper = autoMapper;
        }

        public async Task CancelCartAsync(int cartId)
        {
            var cart = await repositoryManager.Carts.GetCartAsync(cartId, true);
            if (cart != null)
            {
                cart.Status = CartStatus.Cancelled;
                cart.TimeUpdated = DateTime.Now;
                repositoryManager.Carts.Update(cart);
                await repositoryManager.SaveAsync();
            }
        }

        public async Task<CartDto?> GetCartAsync(int cartId, bool trackChanges)
        {
            var cart = await repositoryManager.Carts.GetCartAsync(cartId, trackChanges);
            if(cart == null)
            {
                return null;
            }
            var cartDto = mapper.Map<CartDto>(cart);

            return cartDto;
        }
    }
}
