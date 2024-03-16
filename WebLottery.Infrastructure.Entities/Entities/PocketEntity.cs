using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Infrastructure.Entities.Entities;

public class PocketEntity : Entity
{
    [ForeignKey("User")]
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public List<PocketTicketEntity> PocketTickets { get; set; }
}