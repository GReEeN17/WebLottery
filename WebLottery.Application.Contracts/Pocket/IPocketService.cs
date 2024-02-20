using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Pocket;

namespace WebLottery.Application.Contracts.Pocket;

public interface IPocketService
{
    void CreatePocket(int userId);
    void BuyTicket(int userId, int drawId);
    IEnumerable<DrawModel> GetAllUserDraws(int userId);
}