using Models.Abstractions;
using Models.Users;

namespace Models.Pockets;

public class Pocket : Entity
{
    public User User { get; set; }
    public List<PocketTicket.PocketTicket> PocketTickets { get; set; }
}