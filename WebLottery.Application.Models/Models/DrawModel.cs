using WebLottery.Application.Models.Prize;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Models.Draw;

public class DrawModel
{
    public int Id { get; set; }
    public int TicketPrice { get; set; }
    public int CurrentAmountPlayers { get; set; }
    public int MaxAmountPlayers { get; set; }
    public bool IsEnded { get; set; }
    public int PrizeId { get; set; }
    public PrizeModel? Prize { get; set; }
}