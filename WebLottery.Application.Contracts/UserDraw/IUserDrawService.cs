using Models.Draws;

namespace WebLottery.Application.Contracts.UserDraw;

public interface IUserDrawService
{
    void CreateUserDraw(Guid userId, Guid drawId);
    IEnumerable<Draw> GetUserDraws(Guid userId);
}