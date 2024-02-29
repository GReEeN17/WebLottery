using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.Contracts.Wallet;

public interface IWalletService
{
    Task<int> CreateWallet(int userId);
    Task<WalletCurrencyModel> GetWallet(int walletId);
    Task UpdateWallet(int walletId, int? userId);
    Task DeleteWallet(int walletId);
}