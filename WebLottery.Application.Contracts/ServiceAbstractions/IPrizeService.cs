using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IPrizeService
{
    Task<string> CreatePrize(PrizeModel prizeModel);
    string GetPrize(Guid prizeId);
    Task UpdatePrize(PrizeModel prizeModel);
    Task DeletePrize(Guid prizeId);
}