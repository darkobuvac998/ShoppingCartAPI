namespace ShoppingCart.Contracts.IRepositories
{
    public interface IRepositoryManager
    {
        ICartRepository Carts { get; }
        ICartItemRepository CartItems { get; }
        void Save();
        Task SaveAsync();
    }
}
