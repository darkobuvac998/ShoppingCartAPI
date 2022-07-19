namespace ShoppingCart.Contracts.IServices
{
    public interface IServiceManager
    {
        ICartService CartService { get; }
        ICartItemService CartItemService { get; }
    }
}
