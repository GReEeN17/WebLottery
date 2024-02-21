using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebLottery.Infrastructure.Entities.Pocket;
using WebLottery.Infrastructure.Entities.PocketTicket;
using WebLottery.Infrastructure.Entities.Ticket;

namespace WebLottery.Infrastructure.Implementations.Configuration;

public class PocketTicketConfiguration : IEntityTypeConfiguration<PocketTicketEntity>
{
    public void Configure(EntityTypeBuilder<PocketTicketEntity> builder)
    {
        builder
            .ToTable("pocket_ticket")
            .HasKey(pocketTicket => pocketTicket.Id);

        builder
            .Property(pocketTicket => pocketTicket.PocketId)
            .IsRequired()
            .HasColumnName("pocket_id");

        builder
            .Property(pocketTicket => pocketTicket.TicketId)
            .IsRequired()
            .HasColumnName("ticket_id");

        builder
            .HasOne<PocketEntity>(pocketTicket => pocketTicket.Pocket)
            .WithMany(pocket => pocket.PocketTickets)
            .HasForeignKey(pocketTicket => pocketTicket.PocketId);

        builder
            .HasOne<TicketEntity>(pocketTicket => pocketTicket.Ticket)
            .WithOne(ticket => ticket.PocketTicket);

        builder.Ignore(pocketTicket => pocketTicket.Pocket);

        builder.Ignore(pocketTicket => pocketTicket.Ticket);
    }
}