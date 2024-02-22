using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Infrastructure.Implementations.Repositories;

public class WalletCurrencyRepository : IWalletCurrencyRepository
{
    public Task<WalletCurrencyModel> CreateWalletCurrency(int walletId, int currencyId)
    {
        throw new NotImplementedException();
    }

    public Task<WalletCurrencyModel> GetUserCurrency(int walletId, int currencyId)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<WalletCurrencyModel> GetAllUserCurrency(int walletId)
    {
        throw new NotImplementedException();
    }
}