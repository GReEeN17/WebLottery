using Models.Currencies;

namespace WebLottery.Application.Abstractions.Repositories;

public interface ICurrencyRepository
{
    Task CreateCurrency(string name, string abbreviation);
    Task<string> GetCurrencyNameById(Guid currencyId);
    IEnumerable<Currency> GetAllCurrencies();
}