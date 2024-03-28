using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface ITicketService
{
    Task<TicketEntity> CreateTicket(TicketModel ticketModel);
    string GetTicket(Guid ticketId);
    Task BuyTicket(Guid ticketId);
    IEnumerable<TicketModel> GetNotPurchasedDrawTickets(Guid drawId);
    IEnumerable<TicketModel> GetPurchasedDrawTickets(Guid drawId);
    Task UpdateTicket(TicketModel ticketModel);
    Task DeleteTicket(Guid ticketId);
}