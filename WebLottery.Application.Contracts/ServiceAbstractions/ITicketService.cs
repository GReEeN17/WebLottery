using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface ITicketService
{
    Task<TicketEntity> CreateTicket(TicketModel ticketModel);
    string GetTicket(Guid ticketId);
    string GetDrawTickets(Guid drawId);
    Task UpdateTicket(TicketModel ticketModel);
    Task DeleteTicket(Guid ticketId);
}