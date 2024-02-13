using Models.Abstractions;
using Models.User;

namespace Models.Pocket;

public class PocketEntity : Entity
{
    public UserEntity UserEntity { get; set; }
    public List<PocketTicket.PocketTicketEntity> PocketTickets { get; set; }
}