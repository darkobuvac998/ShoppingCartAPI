namespace ShoppingCart.Entities.DTOs.CartItem
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }

        public int CartId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime TimeCreated { get; set; }

        public DateTime TimeUpdated { get; set; }

        public string CreatedBy { get; set; }

    }
}
