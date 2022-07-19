using ShoppingCart.Entities.Models;

namespace ShoppingCart.Contracts.IRepositories
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<Cart?> GetCartAsync(int cartId, bool trackChanges);
    }
}
