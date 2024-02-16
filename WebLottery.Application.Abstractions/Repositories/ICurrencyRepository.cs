using WebLottery.Application.Models.Currency;

namespace WebLottery.Application.Abstractions.Repositories;

public interface ICurrencyRepository
{
    Task<CurrencyModel> CreateCurrency(string name, string abbreviation);
    Task<CurrencyModel> GetCurrency(int currencyId);
}