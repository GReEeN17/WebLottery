using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.Entities;

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
            .HasOne<CurrencyEntity>(prize => prize.Currency)
            .WithMany(currency => currency.Prizes)
            .HasForeignKey(prize => prize.CurrencyId);
    }
}