using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.Entities.Models;

namespace ShoppingCart.Entities.Configuration
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasData
                (
                    new CartItem
                    {
                        CartItemId = 1,
                        CartId = 1,
                        TimeCreated = DateTime.UtcNow,
                        TimeUpdated = DateTime.UtcNow,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 1 Description",
                        Name = "CartItem 1 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 2,
                        CartId = 1,
                        TimeCreated = DateTime.UtcNow,
                        TimeUpdated = DateTime.UtcNow,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 2 Description",
                        Name = "CartItem 2 Name"
                    }
                );
        }
    }
}
