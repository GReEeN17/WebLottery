using Models.Draws;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IDrawRepository
{
    Task CreateDraw(int ticketPrice, int maxAmountPlayers);
    Task EndDraw(int drawId);
    IAsyncEnumerable<Draw> GetRangeActiveDraws();
    IAsyncEnumerable<Draw> GetUserDraws(int userId);
}