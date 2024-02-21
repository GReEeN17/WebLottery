using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.Draw;
using WebLottery.Infrastructure.Entities.Prize;
using WebLottery.Infrastructure.Entities.Ticket;

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
            .Property(draw => draw.PrizeId)
            .IsRequired()
            .HasColumnName("prize_id");

        builder
            .HasMany<TicketEntity>(draw => draw.Tickets)
            .WithOne(ticket => ticket.Draw)
            .HasForeignKey(ticket => ticket.DrawId);

        builder
            .HasOne<PrizeEntity>(draw => draw.Prize)
            .WithMany(prize => prize.Draws)
            .HasForeignKey(draw => draw.PrizeId);

        builder.Ignore(draw => draw.Prize);

        builder.Ignore(draw => draw.Tickets);
    }
}