using Models.Abstractions;
using Models.Tickets;

namespace Models.Pockets;

public class Pocket : Entity
{
    public Guid PocketId { get; set; }
    public Ticket Ticket { get; set; }
}