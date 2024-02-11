using Models.Abstractions;
using Models.Prizes;

namespace Models.Draws;

public class Draw : Entity
{
    public int TicketPrice { get; set; }
    public int CurrentAmountPlayers { get; set; }
    public int MaxAmountPlayers { get; set; }
    public bool IsEnded { get; set; }
    public Prize Prize { get; set; }
}