using WebLottery.Application.Models.Currency;

namespace WebLottery.Application.Contracts.Currency;

public interface ICurrencyService
{
    Task<string> CreateCurrency(string name, string abbreviation);
    Task<string> GetCurrency(int currencyId);
    Task UpdateCurrency(int currencyId, string? name, string? abbreviation);
    Task DeleteCurrency(int currencyId);
}