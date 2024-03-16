using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Entities;

public class PocketTicketEntity : Entity
{
    public int Id { get; set; }
    [ForeignKey("Pocket")]
    public int PocketId { get; set; }
    public PocketEntity Pocket { get; set; }
    [ForeignKey("Ticket")]
    public int TicketId { get; set; }
    public TicketEntity Ticket { get; set; }
}