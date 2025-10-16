using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebBackend.DataAccess.Entities;

namespace WebBackend.DataAccess.Cofigurations
{
    internal class ManufactureConfiguration : IEntityTypeConfiguration<ManufactureEntity>
    {
        public void Configure(EntityTypeBuilder<ManufactureEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property<string>(x => x.Name)
                .IsRequired();

            builder.Property<string>(x => x.Description)
                .IsRequired();

            builder.HasMany(m => m.Goods)
                .WithOne(g => g.Manufacturer)
                .HasForeignKey(g => g.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
