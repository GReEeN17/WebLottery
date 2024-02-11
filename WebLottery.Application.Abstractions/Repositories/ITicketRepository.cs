using Models.Tickets;

namespace WebLottery.Application.Abstractions.Repositories;

public interface ITicketRepository
{
    Task CreateTicket(int luckyNumber);
    IAsyncEnumerable<Ticket> GetUserTickets(int userId);
}