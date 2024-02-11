using Models.Draws;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IDrawRepository
{
    Task CreateDraw(int ticketPrice, int maxAmountPlayers);
    IAsyncEnumerable<Draw> GetRangeActiveDraws();
    IAsyncEnumerable<Draw> GetUserDraws(Guid userId);
}