using Models.Abstractions;
using Models.Draws;

namespace Models.Tickets;

public class Ticket : Entity
{
    public int LuckyNumber { get; set; }
    public Draw Draw { get; set; }
    public DateTime PurchaseTime { get; set; }
}