using Models.Currencies;

namespace WebLottery.Application.Abstractions.Repositories;

public interface ICurrencyRepository
{
    Task CreateCurrency(string name, string abbreviation);
    Task<Currency> GetCurrencyById(Guid currencyId);
    IAsyncEnumerable<Currency> GetAllCurrencies();
}