using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IWalletCurrencyRepository
{
    Task<WalletCurrencyModel> CreateWalletCurrency(int walletId, int currencyId);
    Task<WalletCurrencyModel> GetWalletCurrency(int walletCurrencyId);
    Task<WalletCurrencyModel> GetUserWalletCurrency(int walletId, int currencyId);
    IAsyncEnumerable<WalletCurrencyModel> GetAllUserWalletCurrency(int walletId);
}