using Models.Abstractions;
using Models.Pockets;
using Models.Tickets;

namespace Models.PocketTicket;

public class PocketTicket : Entity
{
    public Pocket Pocket { get; set; }
    public Ticket Ticket { get; set; }
}