using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IPrizeService
{
    Task<string> CreatePrize(PrizeModel prizeModel);
    string GetPrize(Guid prizeId);
    IEnumerable<PrizeEntity> GetAllPrizes();
    Task UpdatePrize(PrizeModel prizeModel);
    Task DeletePrize(Guid prizeId);
}