using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IDrawService
{
    Task<string> CreateDraw(DrawModel drawModel);
    string GetDraw(int drawId);
    string GetALlDraws();
    string GetSomeDraws(int count);
    Task UpdateDraw(DrawModel drawModel);
    Task DeleteDraw(int drawId);
}