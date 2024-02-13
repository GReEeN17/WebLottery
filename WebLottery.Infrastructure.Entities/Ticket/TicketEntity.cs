using Models.Abstractions;
using Models.Draw;

namespace Models.Ticket;

public class TicketEntity : Entity
{
    public int LuckyNumber { get; set; }
    public DrawEntity DrawEntity { get; set; }
    public DateTime PurchaseTime { get; set; }
}