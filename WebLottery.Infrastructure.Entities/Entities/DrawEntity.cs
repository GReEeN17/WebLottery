using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Entities;

public class DrawEntity : Entity
{
    public int TicketPrice { get; set; }
    public int CurrentAmountPlayers { get; set; }
    public int MaxAmountPlayers { get; set; }
    public bool IsEnded { get; set; }
    [ForeignKey("Prize")]
    public Guid PrizeId { get; set; }
    public PrizeEntity Prize { get; set; }
    public List<TicketEntity> Tickets { get; set; }
}