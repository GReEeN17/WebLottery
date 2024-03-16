using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.Entities;

namespace WebLottery.Infrastructure.Implementations.Configuration;

public class DrawConfiguration : IEntityTypeConfiguration<DrawEntity>
{
    public void Configure(EntityTypeBuilder<DrawEntity> builder)
    {
        builder
            .ToTable("draw")
            .HasKey(draw => draw.Id);
        
        builder
            .Property(draw => draw.TicketPrice)
            .IsRequired()
            .HasColumnName("ticket_price");

        builder
            .Property(draw => draw.MaxAmountPlayers)
            .IsRequired()
            .HasColumnName("max_am_players");

        builder
            .Property(draw => draw.CurrentAmountPlayers)
            .IsRequired()
            .HasColumnName("cur_am_players");

        builder
            .HasOne<PrizeEntity>(draw => draw.Prize)
            .WithMany(prize => prize.Draws)
            .HasForeignKey(draw => draw.PrizeId);
    }
}