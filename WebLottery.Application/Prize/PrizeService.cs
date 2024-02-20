using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Prize;
using WebLottery.Application.Models.Prize;

namespace WebLottery.Application.Prize;

public class PrizeService : IPrizeService
{
    private readonly IPrizeRepository _prizeRepository;
    
    public PrizeService(
        IPrizeRepository prizeRepository)
    {
        _prizeRepository = prizeRepository;
    }
    
    public void CreatePrize(string name, string? description, int? currencyId)
    {
        _prizeRepository.CreatePrize(name, description, currencyId);
    }

    public IEnumerable<PrizeModel> GetAllPrizes()
    {
       return  _prizeRepository.GetAllPrizes().ToBlockingEnumerable();
    }
}