using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IWalletCurrencyRepository
{
    Task<WalletCurrencyModel> CreateWalletCurrency(int walletId, int currencyId);
    Task<WalletCurrencyModel> GetUserCurrency(int walletId, int currencyId);
    IAsyncEnumerable<WalletCurrencyModel> GetAllUserCurrency(int walletId);
}