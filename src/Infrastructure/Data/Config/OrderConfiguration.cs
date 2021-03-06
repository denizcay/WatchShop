using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.BuyerId).IsRequired().HasMaxLength(40);
            builder.OwnsOne(x => x.ShipToAddress, a =>
            {
                a.WithOwner();

                a.Property(x => x.Street).IsRequired().HasMaxLength(180);
                a.Property(x => x.City).IsRequired().HasMaxLength(100);
                a.Property(x => x.State).IsRequired().HasMaxLength(600);
                a.Property(x => x.ZipCode).IsRequired().HasMaxLength(18);
                a.Property(x => x.Country).IsRequired().HasMaxLength(90);
            });

            builder.HasMany(x => x.OrderDetails).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
