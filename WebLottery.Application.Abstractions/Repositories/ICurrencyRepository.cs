using Models.Currencies;

namespace WebLottery.Application.Abstractions.Repositories;

public interface ICurrencyRepository
{
    IEnumerable<Currency> GetAllCurrencies();
}