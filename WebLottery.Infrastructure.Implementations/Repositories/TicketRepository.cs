using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Infrastructure.Implementations.Repositories;

public class TicketRepository : ITicketRepository
{
    public Task<TicketModel> CreateTicket(int drawId, int luckyNumber)
    {
        throw new NotImplementedException();
    }

    public Task<TicketModel> GetTicket(int ticketId)
    {
        throw new NotImplementedException();
    }

    public Task<TicketModel> UpdateTicket(int ticketId)
    {
        throw new NotImplementedException();
    }
}