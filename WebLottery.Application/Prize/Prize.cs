using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Prizes;

namespace WebLottery.Application.Prize;

public class Prize : IPrizeService
{
    private readonly IPrizeRepository _prizeRepository;

    public Prize(
        IPrizeRepository prizeRepository)
    {
        _prizeRepository = prizeRepository;
    }
    
    public void CreatePrize(string name, string? description, int? currencyId)
    {
        _prizeRepository.CreatePrize(name, description, currencyId);
    }

    public IEnumerable<Models.Prize.PrizeModel> GetAllPrizes()
    {
        return _prizeRepository.GetAllPrizes().ToBlockingEnumerable();
    }

    public IEnumerable<Models.Prize.PrizeModel> GetUserPrizes(int userId)
    {
        return _prizeRepository.GetUserPrizes(userId).ToBlockingEnumerable();
    }
}