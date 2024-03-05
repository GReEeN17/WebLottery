using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Contracts.Draw;

public interface IDrawService
{
    Task<string> CreateDraw(DrawModel drawModel);
    string GetDraw(int drawId);
    string GetALlDraws();
    string GetSomeDraws(int count);
    Task UpdateDraw(DrawModel drawModel);
    Task DeleteDraw(int drawId);
}