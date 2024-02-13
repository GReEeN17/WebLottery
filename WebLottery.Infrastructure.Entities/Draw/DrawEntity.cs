using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.Prize;

namespace WebLottery.Infrastructure.Entities.Draw;

public class DrawEntity : Entity
{
    public int Id { get; set; }
    public int TicketPrice { get; set; }
    public int CurrentAmountPlayers { get; set; }
    public int MaxAmountPlayers { get; set; }
    public bool IsEnded { get; set; }
    public PrizeEntity Prize { get; set; }
}