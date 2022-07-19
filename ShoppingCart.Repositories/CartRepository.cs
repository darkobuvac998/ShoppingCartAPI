using Microsoft.EntityFrameworkCore;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Entities.Data;
using ShoppingCart.Entities.Models;

namespace ShoppingCart.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(ShoppingCartDatabaseContext context) : base(context) { }

        public async Task<Cart?> GetCartAsync(int cartId, bool trackChanges)
        {
            return trackChanges ? await dbContext.Carts.FirstOrDefaultAsync(c => c.CartId == cartId)
                : await dbContext.Carts.AsNoTracking().FirstOrDefaultAsync(c => c.CartId == cartId);
        }
    }
}
