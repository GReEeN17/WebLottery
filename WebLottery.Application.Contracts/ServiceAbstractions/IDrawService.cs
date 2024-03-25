using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IDrawService
{
    Task<DrawEntity> CreateDraw(DrawModel drawModel);
    string GetDraw(Guid drawId);
    string GetALlDraws();
    string GetSomeDraws(int count);
    Task UpdateDraw(DrawModel drawModel);
    Task DeleteDraw(Guid drawId);
}