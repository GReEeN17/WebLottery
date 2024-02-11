using Models.Draws;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IUserDrawRepository
{
    Task CreateUserDraw(Guid userId, Guid drawId);
    IAsyncEnumerable<Draw> GetUserDraws(Guid userId);
}