using Models.Prizes;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IPrizeRepository
{
    Task CreatePrize(string name, string? description, int? currencyId);
    IAsyncEnumerable<Prize> GetAllPrizes();
    IAsyncEnumerable<Prize> GetUserPrizes(int userId);
}