using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Models.Prize;

namespace WebLottery.Infrastructure.Implementations.Repositories;

public class PrizeRepository : IPrizeRepository
{
    public Task<PrizeModel> CreatePrize(string name, string? description, int? currencyId)
    {
        throw new NotImplementedException();
    }

    public Task<PrizeModel> GetPrize(int prizeId)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<PrizeModel> GetAllPrizes()
    {
        throw new NotImplementedException();
    }
}