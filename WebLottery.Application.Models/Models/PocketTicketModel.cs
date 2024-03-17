namespace WebLottery.Application.Models.Models;

public class PocketTicketModel
{
    public Guid Id { get; set; }
    public Guid PocketId { get; set; }
    public PocketModel? Pocket { get; set; }
    public Guid TicketId { get; set; }
    public TicketModel? Ticket { get; set; }
}