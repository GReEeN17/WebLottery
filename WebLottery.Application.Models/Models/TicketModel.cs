namespace WebLottery.Application.Models.Models;

public class TicketModel
{
    public Guid Id { get; set; }
    public int LuckyNumber { get; set; }
    public DateTime PurchaseTime { get; set; }
    public int DrawId { get; set; }
    public DrawModel? Draw { get; set; }
    public PocketTicketModel? PocketTicket { get; set; }
}