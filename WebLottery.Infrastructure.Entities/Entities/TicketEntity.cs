using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Entities;

public class TicketEntity : Entity
{
    public int Id { get; set; }
    public int LuckyNumber { get; set; }
    [ForeignKey("Draw")]
    public int DrawId { get; set; }
    public DrawEntity Draw { get; set; }
    public DateTime PurchaseTime { get; set; }
    public PocketTicketEntity PocketTicket { get; set; }
}