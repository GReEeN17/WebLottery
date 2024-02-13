using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.Pocket;
using WebLottery.Infrastructure.Entities.Ticket;

namespace WebLottery.Infrastructure.Entities.PocketTicket;

public class PocketTicketEntity : Entity
{
    public int Id { get; set; }
    public PocketEntity Pocket { get; set; }
    public TicketEntity Ticket { get; set; }
}