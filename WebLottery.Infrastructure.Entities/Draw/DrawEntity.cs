using Models.Abstractions;
using Models.Prize;

namespace Models.Draw;

public class DrawEntity : Entity
{
    public int TicketPrice { get; set; }
    public int CurrentAmountPlayers { get; set; }
    public int MaxAmountPlayers { get; set; }
    public bool IsEnded { get; set; }
    public PrizeEntity PrizeEntity { get; set; }
}