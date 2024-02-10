using Models.Draws;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IDrawRepository
{
    Task CreateDraw(int ticketPrice, int maxAmountPlayers);
    IEnumerable<Draw> GetRangeActiveDraws();
    IEnumerable<Draw> GetUserDraws(Guid userId);
}