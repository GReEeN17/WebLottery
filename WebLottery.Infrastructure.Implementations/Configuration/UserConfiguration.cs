using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Infrastructure.Implementations.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users").HasKey(u => u.Id);
        builder.Property(u => u.EMail).IsRequired().HasMaxLength(256);
        builder.Property(u => u.UserName).IsRequired().HasMaxLength(256);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(256);
    }
}