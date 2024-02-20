using WebLottery.Application.Models.Prize;

namespace WebLottery.Application.Contracts.Prize;

public interface IPrizeService
{
    void CreatePrize(string name, string? description, int? currencyId);
    IEnumerable<PrizeModel> GetAllPrizes();
}