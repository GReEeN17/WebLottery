using Models.Currencies;
using Models.WalletCurrency;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IWalletCurrencyRepository
{
    Task CreateWalletCurrency(int walletId, int currencyId);
    WalletCurrency GetUserWalletCurrency(int walletId, int currencyId);
    IAsyncEnumerable<WalletCurrency> GetAllUserWalletCurrency(int walletId);
}