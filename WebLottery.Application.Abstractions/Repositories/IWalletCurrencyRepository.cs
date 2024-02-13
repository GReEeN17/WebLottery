using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IWalletCurrencyRepository
{
    Task CreateWalletCurrency(int walletId, int currencyId);
    Task<WalletCurrencyModel> GetUserWalletCurrency(int walletId, int currencyId);
    IAsyncEnumerable<WalletCurrencyModel> GetAllUserWalletCurrency(int walletId);
}