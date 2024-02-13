using WebLottery.Application.Models.Pocket;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Models.PocketTicket;

public class PocketTicketModel
{
    public int Id { get; set; }
    public PocketModel Pocket { get; set; }
    public TicketModel Ticket { get; set; }
}