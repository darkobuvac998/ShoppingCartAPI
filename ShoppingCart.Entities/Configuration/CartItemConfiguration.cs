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
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 1 Description",
                        Name = "CartItem 1 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 2,
                        CartId = 1,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 2 Description",
                        Name = "CartItem 2 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 3,
                        CartId = 1,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 3 Description",
                        Name = "CartItem 3 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 4,
                        CartId = 1,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 4 Description",
                        Name = "CartItem 4 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 5,
                        CartId = 1,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 5 Description",
                        Name = "CartItem 5 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 1,
                        CartId = 2,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 1 Description",
                        Name = "CartItem 1 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 2,
                        CartId = 2,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 2 Description",
                        Name = "CartItem 2 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 3,
                        CartId = 2,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 3 Description",
                        Name = "CartItem 3 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 4,
                        CartId = 2,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 4 Description",
                        Name = "CartItem 4 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 5,
                        CartId = 2,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 5 Description",
                        Name = "CartItem 5 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 1,
                        CartId = 3,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 1 Description",
                        Name = "CartItem 1 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 2,
                        CartId = 3,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 2 Description",
                        Name = "CartItem 2 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 3,
                        CartId = 3,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 3 Description",
                        Name = "CartItem 3 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 4,
                        CartId = 3,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 4 Description",
                        Name = "CartItem 4 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 5,
                        CartId = 3,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 5 Description",
                        Name = "CartItem 5 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 1,
                        CartId = 4,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 1 Description",
                        Name = "CartItem 1 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 2,
                        CartId = 4,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 2 Description",
                        Name = "CartItem 2 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 3,
                        CartId = 4,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 3 Description",
                        Name = "CartItem 3 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 4,
                        CartId = 4,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 4 Description",
                        Name = "CartItem 4 Name"
                    },
                    new CartItem
                    {
                        CartItemId = 5,
                        CartId = 4,
                        TimeCreated = DateTime.Now,
                        TimeUpdated = DateTime.Now,
                        CreatedBy = "User 1",
                        Amount = 2,
                        Description = "CartItem 5 Description",
                        Name = "CartItem 5 Name"
                    }
                );
        }
    }
}
