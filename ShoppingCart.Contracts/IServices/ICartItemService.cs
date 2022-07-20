using ShoppingCart.Entities.DTOs.CartItem;

namespace ShoppingCart.Contracts.IServices
{
    public interface ICartItemService
    {
        Task<CartItemDto?> GetCartItemAsync(int cartId, int itemId, bool trackChanges);
        Task<CartItemDto?> AddCartItemAsync(CartItemCreationDto cartItemDto, int cartId);
        Task RemoveCartItemAsync(int cartId, int itemId);
    }
}
