using Models.Abstractions;
using Models.Pocket;
using Models.Ticket;

namespace Models.PocketTicket;

public class PocketTicketEntity : Entity
{
    public PocketEntity PocketEntity { get; set; }
    public TicketEntity TicketEntity { get; set; }
}