using Models.Draws;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IDrawRepository
{
    IEnumerable<Draw> GetRangeActiveDraws();
    IEnumerable<Draw> GetUserDraws(Guid userId);
}