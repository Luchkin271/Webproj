
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebBackend.Core.Models;

namespace WebBackend.DataAccess.Cofigurations
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property<string>(r => r.Context)
                .IsRequired();

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.User.Id)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.ThreadedGood)
                .WithMany(g => g.Reviews)
                .HasForeignKey(r => r.ThreadedGood.Id)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
