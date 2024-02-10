using Models.Tickets;

namespace WebLottery.Application.Abstractions.Repositories;

public interface ITicketRepository
{
    Ticket CreateTicket(int luckyNumber);
    IEnumerable<Ticket> GetUserTickets(Guid userId);
}