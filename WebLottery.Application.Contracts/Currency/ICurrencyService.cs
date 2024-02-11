using Models.Currencies;

namespace WebLottery.Application.Contracts.Currencies;

public interface ICurrencyService
{
    void CreateCurrency(string name, string abbreviation);
    Currency GetCurrencyById(int currencyId);
    IEnumerable<Currency> GetAllCurrencies();
}