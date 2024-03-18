using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Entities;

public class PocketEntity : Entity
{
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    public List<PocketTicketEntity> PocketTickets { get; set; }
}