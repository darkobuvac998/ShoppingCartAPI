using ShoppingCart.Entities.Models;

namespace ShoppingCart.Contracts.IRepositories
{
    public interface ICartItemRepository
    {
        Task<CartItem?> GetCartItemAsync(int cartId, int itemId, bool trackChanges);
    }
}
