using Microsoft.EntityFrameworkCore;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Entities.Data;
using ShoppingCart.Entities.Models;

namespace ShoppingCart.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ShoppingCartDatabaseContext context) : base(context) { }

        public Task<CartItem?> GetCartItemAsync(int cartId, int itemId, bool trackChanges)
        {
            return trackChanges ? dbContext.CartItems.FirstOrDefaultAsync(i => i.CartId == cartId && i.CartItemId == itemId) 
                : dbContext.CartItems.AsNoTracking().FirstOrDefaultAsync(i => i.CartId == cartId && i.CartItemId == itemId);
        }
    }
}
