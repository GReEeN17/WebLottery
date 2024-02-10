using Models;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IWalletRepository
{
    Wallet CreateWallet();
    Wallet? GetUserWallet(Guid userId);
}