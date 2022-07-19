using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Entities.Models
{
    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        [MaxLength(1)]
        [Unicode(false)]
        public CartStatus Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TimeCreated { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TimeUpdated { get; set; }

        [Required]
        [MaxLength(100)]
        [Unicode(false)]
        public string CreatedBy { get; set; }

        [InverseProperty(nameof(CartItem.Cart))]
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }

    public enum CartStatus
    {
        Draft, Cancelled, Submited
    }
}
