using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.PocketTicket;

namespace WebLottery.Application.Models.Ticket;

public class TicketModel
{
    public int Id { get; set; }
    public int LuckyNumber { get; set; }
    public DateTime PurchaseTime { get; set; }
    public int DrawId { get; set; }
    public DrawModel Draw { get; set; }
    public PocketTicketModel PocketTicket { get; set; }
}