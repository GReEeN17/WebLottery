using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Infrastructure.Implementations.Repositories;

public class DrawRepository : IDrawRepository
{
    public Task<DrawModel> CreateDraw(int ticketPrice, int maxAmountPlayers)
    {
        throw new NotImplementedException();
    }

    public Task<DrawModel> GetDraw(int drawId)
    {
        throw new NotImplementedException();
    }

    public Task EndDraw(int drawId)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<DrawModel> GetCurrentDraws()
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<TicketModel> GetNotBoughtTickets(int drawId)
    {
        throw new NotImplementedException();
    }
}