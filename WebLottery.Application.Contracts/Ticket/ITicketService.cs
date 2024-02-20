using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Contracts.Ticket;

public interface ITicketService
{
    void CreateTicket(int drawId, int luckyNumber);
    TicketModel UpdateTicket(int ticketId);
    DrawModel GetUserDraw(int ticketId);
}