using ShoppingCart.Entities.Models;

namespace ShoppingCart.Contracts.IRepositories
{
    public interface ICartItemRepository : IBaseRepository<CartItem>
    {
        Task<CartItem?> GetCartItemAsync(int cartId, int itemId, bool trackChanges);
    }
}
