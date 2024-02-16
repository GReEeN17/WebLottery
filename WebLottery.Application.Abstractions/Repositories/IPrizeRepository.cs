using WebLottery.Application.Models.Prize;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IPrizeRepository
{
    Task<PrizeModel> CreatePrize(string name, string? description, int? currencyId);
    Task<PrizeModel> GetPrize(int prizeId);
    IAsyncEnumerable<PrizeModel> GetAllPrizes();
}