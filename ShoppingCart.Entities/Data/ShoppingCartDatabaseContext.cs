using Microsoft.EntityFrameworkCore;
using ShoppingCart.Entities.Configuration;
using ShoppingCart.Entities.Models;

namespace ShoppingCart.Entities.Data
{
    public partial class ShoppingCartDatabaseContext : DbContext
    {
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }

        public ShoppingCartDatabaseContext(DbContextOptions<ShoppingCartDatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasConversion<int>()
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Navigation(e => e.CartItems).AutoInclude(true);
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.CartItemId, e.CartId });

                entity.Property(e => e.CartItemId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CartItem_Cart");
            });

            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());

        }
    }
}
