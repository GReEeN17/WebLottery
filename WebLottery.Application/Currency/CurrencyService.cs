using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Currencies;

namespace WebLottery.Application.Currency;

public class CurrencyService : ICurrencyService
{
    private readonly ICurrencyRepository _currencyRepository;
    
    public CurrencyService(
        ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }
    
    public void CreateCurrency(string name, string abbreviation)
    {
        _currencyRepository.CreateCurrency(name, abbreviation);
    }

    public Models.Currencies.Currency GetCurrencyById(int currencyId)
    {
        return _currencyRepository.GetCurrencyById(currencyId).Result;
    }

    public IEnumerable<Models.Currencies.Currency> GetAllCurrencies()
    {
        return _currencyRepository.GetAllCurrencies().ToBlockingEnumerable();
    }
}