using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Entities.DTOs.CartItem
{
    public class CartItemCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; set; }
    }
}
