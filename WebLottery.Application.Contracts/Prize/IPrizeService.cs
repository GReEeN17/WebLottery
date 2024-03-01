using WebLottery.Application.Models.Prize;

namespace WebLottery.Application.Contracts.Prize;

public interface IPrizeService
{
    Task<Guid> CreatePrize(PrizeModel prizeModel);
    string GetPrize(int prizeId);
    Task UpdatePrize(PrizeModel prizeModel);
    Task DeletePrize(int prizeId);
}