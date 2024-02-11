using Models;

namespace WebLottery.Application.Contracts.Wallets;

public interface IWalletService
{
    Task CreateWallet();
    Wallet GetUserWallet(Guid userId);
}