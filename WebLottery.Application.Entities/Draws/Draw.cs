using Models.Abstractions;

namespace Models.Draws;

public class Draw : Entity
{
    public Guid DrawId { get; set; }
    public int TicketPrice { get; set; }
    public int CurrentAmountPlayers { get; set; }
    public int MaxAmountPlayers { get; set; }
    public bool IsEnded { get; set; }
}