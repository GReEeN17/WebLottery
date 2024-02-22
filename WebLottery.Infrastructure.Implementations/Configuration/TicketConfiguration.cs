using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.Draw;
using WebLottery.Infrastructure.Entities.PocketTicket;
using WebLottery.Infrastructure.Entities.Ticket;

namespace WebLottery.Infrastructure.Implementations.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<TicketEntity>
{
    public void Configure(EntityTypeBuilder<TicketEntity> builder)
    {
        builder
            .ToTable("ticket")
            .HasKey(ticket => ticket.Id);

        builder
            .Property(ticket => ticket.LuckyNumber)
            .IsRequired()
            .HasColumnName("lucky_number");

        builder
            .Property(ticket => ticket.DrawId)
            .IsRequired()
            .HasColumnName("draw_id");

        builder
            .HasOne<DrawEntity>(ticket => ticket.Draw)
            .WithMany(draw => draw.Tickets)
            .HasForeignKey(ticket => ticket.DrawId);

        builder.Ignore(ticket => ticket.Draw);
        builder.Ignore(ticket => ticket.PocketTicket);
    }
}