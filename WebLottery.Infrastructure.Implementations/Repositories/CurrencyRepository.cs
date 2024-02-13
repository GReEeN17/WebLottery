using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Models.Currency;

namespace WebLottery.Infrastructure.Implementations.Repositories;

public class CurrencyRepository : ICurrencyRepository
{
    private readonly DataContext.DataContext _context;

    public CurrencyRepository(DataContext.DataContext context)
    {
        _context = context;
    }
    
    public Task CreateCurrency(string name, string abbreviation)
    {
        throw new NotImplementedException();
    }

    public Task<CurrencyModel> GetCurrencyById(int currencyId)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<CurrencyModel> GetAllCurrencies()
    {
        throw new NotImplementedException();
    }
}