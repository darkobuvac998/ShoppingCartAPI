using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Entities.Data;

namespace ShoppingCart.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ShoppingCartDatabaseContext dbContext;
        private readonly Lazy<ICartRepository> cartRepository;
        private readonly Lazy<ICartItemRepository> cartItemRepository;

        public RepositoryManager(ShoppingCartDatabaseContext context)
        {
            dbContext = context;
            cartRepository = new Lazy<ICartRepository>(() => new CartRepository(context));
            cartItemRepository = new Lazy<ICartItemRepository>(() => new CartItemRepository(context));
        }

        public ICartRepository Carts => cartRepository.Value;

        public ICartItemRepository CartItems => cartItemRepository.Value;

        public void Save() => dbContext.SaveChanges();

        public async Task SaveAsync() => await dbContext.SaveChangesAsync();
    }
}
