using Models.Tickets;

namespace WebLottery.Application.Abstractions.Repositories;

public interface ITicketRepository
{
    IEnumerable<Ticket> GetUserTickets(Guid userId);
}