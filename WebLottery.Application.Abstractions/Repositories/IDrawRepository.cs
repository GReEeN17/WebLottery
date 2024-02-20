using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IDrawRepository
{
    Task<DrawModel> CreateDraw(int ticketPrice, int maxAmountPlayers);
    Task<DrawModel> GetDraw(int drawId);
    Task EndDraw(int drawId);
    IAsyncEnumerable<DrawModel> GetCurrentDraws();
    IAsyncEnumerable<TicketModel> GetNotBoughtTickets(int drawId);
}