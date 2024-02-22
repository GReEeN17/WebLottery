using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.User;
using WebLottery.Infrastructure.Entities.Wallet;
using WebLottery.Infrastructure.Entities.WalletCurrency;

namespace WebLottery.Infrastructure.Implementations.Configuration;

public class WalletConfiguration : IEntityTypeConfiguration<WalletEntity>
{
    public void Configure(EntityTypeBuilder<WalletEntity> builder)
    {
        builder
            .ToTable("wallet")
            .HasKey(wallet => wallet.Id);

        builder
            .Property(wallet => wallet.UserId)
            .IsRequired()
            .HasColumnName("user_id");

        builder
            .HasMany<WalletCurrencyEntity>(wallet => wallet.WalletCurrencies)
            .WithOne(walletCurrency => walletCurrency.Wallet)
            .HasForeignKey(walletCurrency => walletCurrency.WalletId);

        builder.Ignore(wallet => wallet.User);
    }
}