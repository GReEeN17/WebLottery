using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.Draw;

namespace WebLottery.Infrastructure.Entities.Ticket;

public class TicketEntity : Entity
{
    public int Id { get; set; }
    public int LuckyNumber { get; set; }
    public DrawEntity Draw { get; set; }
    public DateTime PurchaseTime { get; set; }
}