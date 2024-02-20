using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Models.Currency;

namespace WebLottery.Infrastructure.Implementations.Repositories;

public class CurrencyRepository : ICurrencyRepository
{
    public Task<CurrencyModel> CreateCurrency(string name, string abbreviation)
    {
        throw new NotImplementedException();
    }

    public Task<CurrencyModel> GetCurrency(int currencyId)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<CurrencyModel> GetAllCurrencies()
    {
        throw new NotImplementedException();
    }
}