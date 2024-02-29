using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Contracts.Ticket;

public interface ITicketService
{
    Task<string> CreateTicket(int drawId, int luckyNumber);
    Task<TicketModel> GetTicket(int ticketId);
    Task UpdateTicket(int ticketId, int? drawId, int? luckyNumber);
    Task DeleteTicket(int ticketId);
}