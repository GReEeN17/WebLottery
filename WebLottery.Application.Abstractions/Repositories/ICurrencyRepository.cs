using WebLottery.Application.Models.Currency;

namespace WebLottery.Application.Abstractions.Repositories;

public interface ICurrencyRepository
{
    Task CreateCurrency(string name, string abbreviation);
    Task<CurrencyModel> GetCurrencyById(int currencyId);
    IAsyncEnumerable<CurrencyModel> GetAllCurrencies();
}