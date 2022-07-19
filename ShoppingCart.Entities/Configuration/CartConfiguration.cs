using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.Entities.Models;

namespace ShoppingCart.Entities.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasData
                (
                    new Cart
                    {
                        CartId = 1,
                        Status = CartStatus.Draft,
                        TimeCreated = DateTime.UtcNow,
                        TimeUpdated = DateTime.UtcNow,
                        CreatedBy = "User 1"
                    },
                    new Cart
                    {
                        CartId = 2,
                        Status = CartStatus.Draft,
                        CreatedBy = "User 2",
                        TimeUpdated = DateTime.UtcNow,
                        TimeCreated = DateTime.UtcNow,
                    },
                    new Cart
                    {
                        CartId = 3,
                        Status = CartStatus.Draft,
                        CreatedBy = "User 3",
                        TimeUpdated = DateTime.UtcNow,
                        TimeCreated = DateTime.UtcNow,
                    }
                );
        }
    }
}
