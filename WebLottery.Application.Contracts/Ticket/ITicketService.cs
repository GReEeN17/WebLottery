using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Contracts.Ticket;

public interface ITicketService
{
    Task<string> CreateTicket(TicketModel ticketModel);
    string GetTicket(int ticketId);
    string GetDrawTickets(int drawId);
    Task UpdateTicket(TicketModel ticketModel);
    Task DeleteTicket(int ticketId);
}