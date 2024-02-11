using Models.Currencies;

namespace WebLottery.Application.Contracts.Currencies;

public interface ICurrencyService
{
    void CreateCurrency(string name, string abbreviation);
    Currency GetCurrencyById(Guid currencyId);
    IEnumerable<Currency> GetAllCurrencies();
}