using Models.Draws;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IUserDrawRepository
{
    Task CreateUserDraw(int userId, int drawId);
    IAsyncEnumerable<Draw> GetUserDraws(int userId);
}