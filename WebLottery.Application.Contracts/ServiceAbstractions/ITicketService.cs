using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface ITicketService
{
    Task<string> CreateTicket(TicketModel ticketModel);
    string GetTicket(Guid ticketId);
    string GetDrawTickets(Guid drawId);
    Task UpdateTicket(TicketModel ticketModel);
    Task DeleteTicket(Guid ticketId);
}