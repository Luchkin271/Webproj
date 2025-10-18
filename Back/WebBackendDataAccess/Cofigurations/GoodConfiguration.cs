using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebBackend.DataAccess.Entities;

namespace WebBackend.DataAccess.Cofigurations
{
    public class GoodConfiguration : IEntityTypeConfiguration<GoodEntity>
    {
        public void Configure(EntityTypeBuilder<GoodEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property<string>(x => x.Name)
                .IsRequired();

            builder.Property<string>(x => x.Price)
                .IsRequired();

            builder.Property<string>(x => x.Description)
                .IsRequired();

            builder.Property<string>(x => x.Specifications)
                .IsRequired();

            builder.Property<string>(x => x.IconURL)
                .IsRequired();

            builder.HasOne(g => g.Manufacturer)
                .WithMany(m => m.Goods)
                .HasForeignKey(g => g.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.Reviews)
                .WithOne(r => r.ThreadedGood)
                .HasForeignKey(r => r.ThreadedGoodId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
