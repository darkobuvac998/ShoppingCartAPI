using ShoppingCart.Entities.DTOs.CartItem;

namespace ShoppingCart.Contracts.IServices
{
    public interface ICartItemService
    {
        Task<CartItemDto?> GetCartItemAsync(int cartId, int itemId, bool trackChanges);
    }
}
