using WebLottery.Application.Contracts.Draw;
using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.Draw;

public class DrawService : IDrawService
{
    public Task<string> CreateDraw(DrawModel drawModel)
    {
        throw new NotImplementedException();
    }

    public string GetDraw(int drawId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDraw(DrawModel drawModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDraw(int drawId)
    {
        throw new NotImplementedException();
    }
}