using WebLottery.Application.Models.Wallet;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IWalletRepository
{
    Task<WalletModel> CreateWallet(int userId);
    Task<WalletModel> GetWallet(int walletId);
    Task<int> GetUserWallet(int userId);
}