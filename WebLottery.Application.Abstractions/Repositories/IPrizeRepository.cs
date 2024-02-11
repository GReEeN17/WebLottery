using Models.Prizes;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IPrizeRepository
{
    Task CreatePrize();
    IAsyncEnumerable<Prize> GetAllPrizes();
    IAsyncEnumerable<Prize> GetUserPrizes(Guid userId);
}