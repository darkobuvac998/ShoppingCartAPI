namespace ShoppingCart.Entities.DTOs.Cart
{
    public class CartDto
    {
        public int CartId { get; set; }

        public string Status { get; set; }

        public DateTime TimeCreated { get; set; }

        public DateTime TimeUpdated { get; set; }

        public string CreatedBy { get; set; }

        public virtual ICollection<CartItemShortDto>? CartItems { get; set; }
    }

    public class CartItemShortDto
    {
        public int CartItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
