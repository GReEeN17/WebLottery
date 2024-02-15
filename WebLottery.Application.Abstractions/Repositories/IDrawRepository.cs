using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IDrawRepository
{
    Task<DrawModel> CreateDraw(int ticketPrice, int maxAmountPlayers);
    Task<DrawModel> GetDraw(int drawId);
    Task EndDraw(int drawId);
    IAsyncEnumerable<DrawModel> GetRangeActiveDraws();
    IAsyncEnumerable<DrawModel> GetUserDraws(int userId);
}