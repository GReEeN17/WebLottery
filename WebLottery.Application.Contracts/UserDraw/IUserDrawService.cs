using Models.Draws;

namespace WebLottery.Application.Contracts.UserDraw;

public interface IUserDrawService
{
    void CreateUserDraw(int userId, int drawId);
    IEnumerable<Draw> GetUserDraws(int userId);
}