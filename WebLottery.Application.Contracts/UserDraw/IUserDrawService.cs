using Models.Draw;
using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.Contracts.UserDraw;

public interface IUserDrawService
{
    void CreateUserDraw(int userId, int drawId);
    IEnumerable<DrawModel> GetUserDraws(int userId);
}