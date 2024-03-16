using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface ICurrencyService
{
    Task<string> CreateCurrency(CurrencyModel currencyModel);
    string GetCurrency(int currencyId);
    string GetAllCurrencies();
    Task UpdateCurrency(CurrencyModel currencyModel);
    Task DeleteCurrency(int currencyId);
}