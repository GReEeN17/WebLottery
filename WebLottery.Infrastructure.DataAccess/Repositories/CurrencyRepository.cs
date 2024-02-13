using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Models.Currency;

namespace WebLottery.Infrastructure.DataAccess.Repositories;

public class CurrencyRepository : ICurrencyRepository
{
    public Task CreateCurrency(string name, string abbreviation)
    {
        throw new NotImplementedException();
    }

    public Task<CurrencyModel> GetCurrencyById(int currencyId)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<CurrencyModel> GetAllCurrencies()
    {
        throw new NotImplementedException();
    }
}