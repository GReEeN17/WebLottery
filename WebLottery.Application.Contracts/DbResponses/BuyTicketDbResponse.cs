namespace WebLottery.Application.Contracts.DbResponses;

public class BuyTicketDbResponse
{
    public Guid DrawId { get; set; }
    public int LuckyNumber { get; set; }
}