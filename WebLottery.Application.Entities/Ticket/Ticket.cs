using Models.Abstractions;

namespace Models.Tickets;

public class Ticket : Entity
{
    public int LuckyNumber { get; set; }
    public DateTime PurchaseTime { get; set; }
}