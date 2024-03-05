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
            .HasOne<TicketEntity>(pocketTicket => pocketTicket.Ticket)
            .WithOne(ticket => ticket.PocketTicket)
            .HasForeignKey<PocketTicketEntity>(pocketTicket => pocketTicket.TicketId);
    }
}