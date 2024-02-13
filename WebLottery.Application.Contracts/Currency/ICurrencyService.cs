using Models.Currency;
using WebLottery.Application.Models.Currency;

namespace WebLottery.Application.Contracts.Currencies;

public interface ICurrencyService
{
    void CreateCurrency(string name, string abbreviation);
    CurrencyModel GetCurrencyById(int currencyId);
    IEnumerable<CurrencyModel> GetAllCurrencies();
}