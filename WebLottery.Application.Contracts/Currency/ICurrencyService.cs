using WebLottery.Application.Models.Currency;

namespace WebLottery.Application.Contracts.Currency;

public interface ICurrencyService
{
    Task<string> CreateCurrency(CurrencyModel currencyModel);
    string GetCurrency(int currencyId);
    string GetAllCurrencies();
    Task UpdateCurrency(CurrencyModel currencyModel);
    Task DeleteCurrency(int currencyId);
}