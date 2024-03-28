using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Entities;

public class TicketEntity : Entity
{
    public int LuckyNumber { get; set; }
    [ForeignKey("Draw")]
    public Guid DrawId { get; set; }
    public DrawEntity Draw { get; set; }
    public DateTime? PurchaseTime { get; set; }
    public bool Lucky { get; set; }
    public PocketTicketEntity PocketTicket { get; set; }
}