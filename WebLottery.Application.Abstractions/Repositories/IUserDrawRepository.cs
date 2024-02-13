using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IUserDrawRepository
{
    Task CreateUserDraw(int userId, int drawId);
    IAsyncEnumerable<DrawModel> GetUserDraws(int userId);
}