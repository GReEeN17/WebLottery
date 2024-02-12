using Models.Tickets;

namespace WebLottery.Application.Contracts.Tcikets;

public interface ITicketService
{
    Ticket CreateTicket(int drawId, int luckyNumber);
}