using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Entities.Models
{
    [Table("CartItem")]
    public partial class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        [Key]
        public int CartId { get; set; }

        [Required]
        [MaxLength(100)]
        [Unicode(false)]
        public string Name { get; set; }

        [MaxLength(200)]
        [Unicode(false)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TimeCreated { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TimeUpdated { get; set; }

        [Required]
        [MaxLength(100)]
        [Unicode(false)]
        public string CreatedBy { get; set; }

        [ForeignKey(nameof(CartId))]
        [InverseProperty("CartItems")]
        public virtual Cart Cart { get; set; }
    }
}
