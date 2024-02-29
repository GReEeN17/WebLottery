using WebLottery.Application.Contracts.Currency;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Implementations.AbstractionTrigger;

namespace WebLottery.Application.Currency;

public class CurrencyService : ICurrencyService
{
    private readonly IDbRepository _currencyRepository;
    
    public CurrencyService(
        IDbRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }
    
    public void CreateCurrency(string name, string abbreviation)
    {
        _currencyRepository.CreateCurrency(name, abbreviation);
    }

    public Models.Currency.CurrencyModel GetCurrency(int currencyId)
    {
        return _currencyRepository.GetCurrency(currencyId).Result;
    }
}