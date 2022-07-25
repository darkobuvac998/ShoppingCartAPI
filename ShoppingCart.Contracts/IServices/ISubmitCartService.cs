namespace ShoppingCart.Contracts.IServices
{
    public interface ISubmitCartService
    {
        Task<bool> SubmitCart(object preparedCartForSubmit);
    }
}
