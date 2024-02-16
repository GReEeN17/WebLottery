using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.Contracts.Draw;

public interface IDrawService
{
    void CreateDraw(int ticketPrice, int maxAmountPlayers);
    void EndDraw(int drawId);
    DrawModel GetDraw(int drawId);
    IEnumerable<DrawModel> GetCurrentDraws();
}