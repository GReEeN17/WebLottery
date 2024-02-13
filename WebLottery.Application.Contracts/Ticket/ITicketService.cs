using Models.Ticket;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Contracts.Tcikets;

public interface ITicketService
{
    TicketModel CreateTicket(int drawId, int luckyNumber);
}