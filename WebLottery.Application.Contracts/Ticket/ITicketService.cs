using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Contracts.Ticket;

public interface ITicketService
{
    TicketModel CreateTicket(int drawId, int luckyNumber);
}