using Models;

namespace WebLottery.Application.Contracts.Wallets;

public interface IWalletService
{
    void CreateWallet();
    Wallet GetUserWallet(Guid userId);
}