namespace ShoppingCart.IntegrationTests
{
    public static class ApiRoutes
    {
        private const string root = "api";

        public static class Get 
        {
            public static string GetCartItemAsync(int cartId, int itemId) => $"{root}/cart/{cartId}/cartItem/{itemId}";
            public static string GetCartAsync(int cartId) => $"{root}/cart/{cartId}";
        }

        public static class Post
        {
            public static string AddCartItemAsync(int cartId) => $"{root}/cart/{cartId}/cartItem";
        }
    }
}
