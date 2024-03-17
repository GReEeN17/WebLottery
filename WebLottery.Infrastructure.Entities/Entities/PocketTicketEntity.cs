using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Entities;

public class PocketTicketEntity : Entity
{
    [ForeignKey("Pocket")]
    public Guid PocketId { get; set; }
    public PocketEntity Pocket { get; set; }
    [ForeignKey("Ticket")]
    public Guid TicketId { get; set; }
    public TicketEntity Ticket { get; set; }
}