using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.Models.Ticket;

public class TicketModel
{
    public int Id { get; set; }
    public int LuckyNumber { get; set; }
    public DateTime PurchaseTime { get; set; }
}