using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.Contracts.Pocket;

public interface IPocketService
{
    void CreatePocket(int userId);
    void BuyTicket(int userId, int luckyNumber, int drawId);
    IEnumerable<DrawModel> GetAllUserDraws(int userId);
}