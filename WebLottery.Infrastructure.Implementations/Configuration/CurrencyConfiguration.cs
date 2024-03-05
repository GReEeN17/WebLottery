using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Entities.Prize;
using WebLottery.Infrastructure.Entities.WalletCurrency;

namespace WebLottery.Infrastructure.Implementations.Configuration;

public class CurrencyConfiguration : IEntityTypeConfiguration<CurrencyEntity>
{
    public void Configure(EntityTypeBuilder<CurrencyEntity> builder)
    {
        builder
            .ToTable("currency")
            .HasKey(currency => currency.Id);
        
        builder
            .Property(currency => currency.Abbreviation)
            .IsRequired()
            .HasMaxLength(3)
            .HasColumnName("abbreviation");
        
        builder
            .Property(currency => currency.Name)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("name");
    }
}