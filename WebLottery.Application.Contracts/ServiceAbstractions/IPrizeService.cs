using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IPrizeService
{
    Task<string> CreatePrize(PrizeModel prizeModel);
    string GetPrize(int prizeId);
    Task UpdatePrize(PrizeModel prizeModel);
    Task DeletePrize(int prizeId);
}