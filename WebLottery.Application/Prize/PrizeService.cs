using WebLottery.Application.Contracts.Prize;
using WebLottery.Application.Models.Prize;

namespace WebLottery.Application.Prize;

public class PrizeService : IPrizeService
{
    public Task<Guid> CreatePrize(PrizeModel prizeModel)
    {
        throw new NotImplementedException();
    }

    public string GetPrize(int prizeId)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePrize(PrizeModel prizeModel)
    {
        throw new NotImplementedException();
    }

    public Task DeletePrize(int prizeId)
    {
        throw new NotImplementedException();
    }
}