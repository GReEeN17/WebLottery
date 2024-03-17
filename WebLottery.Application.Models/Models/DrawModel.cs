namespace WebLottery.Application.Models.Models;

public class DrawModel
{
    public Guid Id { get; set; }
    public int TicketPrice { get; set; }
    public int CurrentAmountPlayers { get; set; }
    public int MaxAmountPlayers { get; set; }
    public bool IsEnded { get; set; }
    public Guid PrizeId { get; set; }
    public PrizeModel? Prize { get; set; }
}