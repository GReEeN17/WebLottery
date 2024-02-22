using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Entities.Wallet;
using WebLottery.Infrastructure.Entities.WalletCurrency;

namespace WebLottery.Infrastructure.Implementations.Configuration;

public class WalletCurrencyConfiguration : IEntityTypeConfiguration<WalletCurrencyEntity>
{
    public void Configure(EntityTypeBuilder<WalletCurrencyEntity> builder)
    {
        builder
            .ToTable("wallet_currency")
            .HasKey(walletCurrency => walletCurrency.Id);

        builder
            .Property(walletCurrency => walletCurrency.CurrencyId)
            .IsRequired()
            .HasColumnName("column_id");

        builder.Property(walletCurrency => walletCurrency.WalletId)
            .IsRequired()
            .HasColumnName("wallet_id");

        builder.Property(walletCurrency => walletCurrency.Amount)
            .IsRequired()
            .HasColumnName("amount");

        builder
            .HasOne<CurrencyEntity>(walletCurrency => walletCurrency.Currency)
            .WithMany(currency => currency.WalletCurrencies)
            .HasForeignKey(walletCurrency => walletCurrency.CurrencyId);

        builder.Ignore(walletCurrency => walletCurrency.Currency);

        builder.Ignore(walletCurrency => walletCurrency.Wallet);

    }
}