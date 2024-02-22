using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Entities.Draw;
using WebLottery.Infrastructure.Entities.Prize;

namespace WebLottery.Infrastructure.Implementations.Configuration;

public class PrizeConfiguration : IEntityTypeConfiguration<PrizeEntity>
{
    public void Configure(EntityTypeBuilder<PrizeEntity> builder)
    {
        builder
            .ToTable("prize")
            .HasKey(prize => prize.Id);

        builder
            .Property(prize => prize.Name)
            .IsRequired()
            .HasMaxLength(64)
            .HasColumnName("name");

        builder
            .Property(prize => prize.Description)
            .HasMaxLength(1024)
            .HasColumnName("description");

        builder
            .Property(prize => prize.CurrencyId)
            .HasColumnName("currency_id");

        builder
            .HasOne<CurrencyEntity>(prize => prize.Currency)
            .WithMany(currency => currency.Prizes)
            .HasForeignKey(prize => prize.CurrencyId);

        builder.Ignore(prize => prize.Currency);
        
        builder.Ignore(prize => prize.Draws);
    }
}