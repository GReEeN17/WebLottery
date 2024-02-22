using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Models.Pocket;

namespace WebLottery.Infrastructure.Implementations.Repositories;

public class PocketRepository : IPocketRepository
{
    public Task<PocketModel> CreatePocket(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<PocketModel> GetPocket(int userId)
    {
        throw new NotImplementedException();
    }
}