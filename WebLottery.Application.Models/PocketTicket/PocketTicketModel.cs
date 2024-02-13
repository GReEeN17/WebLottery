using WebLottery.Application.Models.Pocket;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Models.PocketTicket;

public class PocketTicketModel
{
    public int Id { get; set; }
    public PocketModel PocketEntity { get; set; }
    public TicketModel TicketEntity { get; set; }
}