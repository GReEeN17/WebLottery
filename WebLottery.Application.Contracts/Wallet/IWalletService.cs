using WebLottery.Application.Models.Wallet;
using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.Contracts.Wallet;

public interface IWalletService
{
    Task<int> CreateWallet(WalletModel walletModel);
    string GetWallet(int walletId);
    Task UpdateWallet(WalletModel walletModel);
    Task DeleteWallet(int walletId);
}