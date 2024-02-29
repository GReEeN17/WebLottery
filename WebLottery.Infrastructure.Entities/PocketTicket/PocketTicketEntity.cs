using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.Pocket;
using WebLottery.Infrastructure.Entities.Ticket;

namespace WebLottery.Infrastructure.Entities.PocketTicket;

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