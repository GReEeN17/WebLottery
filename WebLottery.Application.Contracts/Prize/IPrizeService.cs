using Models.Prizes;

namespace WebLottery.Application.Contracts.Prizes;

public interface IPrizeService
{
    void CreatePrize(string name, string? description, int? currencyId);
    IEnumerable<Prize> GetAllPrizes();
    IEnumerable<Prize> GetUserPrizes(int userId);
}