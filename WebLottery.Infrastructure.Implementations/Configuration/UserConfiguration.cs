using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.Entities;

namespace WebLottery.Infrastructure.Implementations.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .ToTable("user")
            .HasKey(user => user.Id);
        
        builder
            .Property(user => user.EMail)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("email");
        
        builder
            .Property(user => user.UserName)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("username");
        
        builder
            .Property(user => user.Password)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("password");
        
        builder
            .HasOne<WalletEntity>(user => user.Wallet)
            .WithOne(wallet => wallet.User)
            .HasForeignKey<WalletEntity>(wallet => wallet.UserId);
        
        builder
            .HasOne<PocketEntity>(user => user.Pocket)
            .WithOne(pocket => pocket.User)
            .HasForeignKey<PocketEntity>(pocket => pocket.UserId);
    }
}