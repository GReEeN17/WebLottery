using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IDrawRepository
{
    Task CreateDraw(int ticketPrice, int maxAmountPlayers);
    Task EndDraw(int drawId);
    IAsyncEnumerable<DrawModel> GetRangeActiveDraws();
    IAsyncEnumerable<DrawModel> GetUserDraws(int userId);
}