using Models.Prizes;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IPrizeRepository
{
    IEnumerable<Prize> GetAllPrizes();
    IEnumerable<Prize> GetUserPrizes(Guid userId);
}