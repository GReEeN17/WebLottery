using Models.Prize;
using WebLottery.Application.Models.Prize;

namespace WebLottery.Application.Contracts.Prizes;

public interface IPrizeService
{
    void CreatePrize(string name, string? description, int? currencyId);
    IEnumerable<PrizeModel> GetAllPrizes();
    IEnumerable<PrizeModel> GetUserPrizes(int userId);
}