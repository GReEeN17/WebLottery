using WebLottery.Application.Models.Currency;

namespace WebLottery.Application.Contracts.Currency;

public interface ICurrencyService
{
    void CreateCurrency(string name, string abbreviation);
    CurrencyModel GetCurrencyById(int currencyId);
    IEnumerable<CurrencyModel> GetAllCurrencies();
}