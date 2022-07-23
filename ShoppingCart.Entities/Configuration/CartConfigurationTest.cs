using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.Entities.Models;

namespace ShoppingCart.Entities.Configuration
{
    internal class CartConfigurationTest : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasData
                (
                    new Cart
                    {
                        CartId = 1,
                        Status = CartStatus.Draft,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1"
                    }
                );
        }
    }
}
