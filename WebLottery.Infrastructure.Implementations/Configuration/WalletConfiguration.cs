using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Infrastructure.Implementations.Configuration;

public class WalletConfiguration : IEntityTypeConfiguration<WalletEntity>
{
    public void Configure(EntityTypeBuilder<WalletEntity> builder)
    {
        builder
            .ToTable("wallet")
            .HasKey(wallet => wallet.Id);

        builder
            .HasMany<WalletCurrencyEntity>(wallet => wallet.WalletCurrencies)
            .WithOne(walletCurrency => walletCurrency.Wallet)
            .HasForeignKey(walletCurrency => walletCurrency.WalletId);
    }
}