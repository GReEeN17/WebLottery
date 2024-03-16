using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface ITicketService
{
    Task<string> CreateTicket(TicketModel ticketModel);
    string GetTicket(int ticketId);
    string GetDrawTickets(int drawId);
    Task UpdateTicket(TicketModel ticketModel);
    Task DeleteTicket(int ticketId);
}