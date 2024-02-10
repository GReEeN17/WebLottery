using Models.Currencies;

namespace WebLottery.Application.Abstractions.Repositories;

public interface ICurrencyRepository
{
    Task CreateCurrency(string name, string abbreviation);
    IEnumerable<Currency> GetAllCurrencies();
}