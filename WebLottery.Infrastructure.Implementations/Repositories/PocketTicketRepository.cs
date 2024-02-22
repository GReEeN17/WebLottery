using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Models.PocketTicket;

namespace WebLottery.Infrastructure.Implementations.Repositories;

public class PocketTicketRepository : IPocketTicketRepository
{
    public Task<PocketTicketModel> CreatePocketTicket(int pocketId, int ticketId)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<PocketTicketModel> GetPocketTickets(int pocketId)
    {
        throw new NotImplementedException();
    }
}