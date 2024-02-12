using Models.Tickets;

namespace WebLottery.Application.Abstractions.Repositories;

public interface ITicketRepository
{
    Task<Ticket> CreateTicket(int drawId, int luckyNumber);
}