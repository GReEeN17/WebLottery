namespace WebLottery.Application.Contracts.DbResponses;

public class CreateDrawDbResponse
{
    public Guid DrawId { get; set; }
    public int TicketPrice { get; set; }
    public int MaxAmountPlayers { get; set; }
}