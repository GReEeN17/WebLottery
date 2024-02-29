using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Infrastructure.Entities.Pocket;

public class PocketEntity : Entity
{
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public List<PocketTicket.PocketTicketEntity> PocketTickets { get; set; }
}