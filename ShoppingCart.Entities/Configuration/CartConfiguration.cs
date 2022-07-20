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
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1"
                    },
                    new Cart
                    {
                        CartId = 2,
                        Status = CartStatus.Draft,
                        CreatedBy = "User 2",
                        TimeUpdated = DateTime.Now,
                        TimeCreated = DateTime.Now,
                    },
                    new Cart
                    {
                        CartId = 3,
                        Status = CartStatus.Submited,
                        CreatedBy = "User 3",
                        TimeUpdated = DateTime.Now,
                        TimeCreated = DateTime.Now,
                    },
                    new Cart
                    {
                        CartId = 4,
                        Status = CartStatus.Cancelled,
                        CreatedBy = "User 1",
                        TimeUpdated = DateTime.Now,
                        TimeCreated = DateTime.Now,
                    },
                    new Cart
                    {
                        CartId = 5,
                        Status = CartStatus.Cancelled,
                        CreatedBy = "User 1",
                        TimeUpdated = DateTime.Now,
                        TimeCreated = DateTime.Now,
                    }
                );
        }
    }
}
