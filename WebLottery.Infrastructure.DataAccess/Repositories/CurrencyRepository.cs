using Models.Currencies;
using WebLottery.Application.Abstractions.Repositories;

namespace WebLottery.Infrastructure.DataAccess.Repositories;

public class CurrencyRepository : ICurrencyRepository
{
    public Task CreateCurrency(string name, string abbreviation)
    {
        throw new NotImplementedException();
    }

    public Task<Currency> GetCurrencyById(int currencyId)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<Currency> GetAllCurrencies()
    {
        throw new NotImplementedException();
    }
}