
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebBackend.Core.Models;
using WebBackend.DataAccess.Entities;

namespace WebBackend.DataAccess.Cofigurations
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<ReviewEntity>
    {
        public void Configure(EntityTypeBuilder<ReviewEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property<string>(r => r.Context)
                .IsRequired();

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.ThreadedGood)
                .WithMany(g => g.Reviews)
                .HasForeignKey(r => r.ThreadedGoodId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
