using WebLottery.Application.Models.Prize;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IPrizeRepository
{
    Task CreatePrize(string name, string? description, int? currencyId);
    IAsyncEnumerable<PrizeModel> GetAllPrizes();
    IAsyncEnumerable<PrizeModel> GetUserPrizes(int userId);
}