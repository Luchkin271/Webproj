using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebBackend.DataAccess.Entities;

namespace WebBackend.DataAccess.Cofigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property<string>(u => u.Name);
            
            builder.Property<string>(u => u.Email);

            builder.Property<bool>(u => u.IsEmailConfirmed);

            builder.Property<string>(u => u.PasswordHash);

            builder.HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
