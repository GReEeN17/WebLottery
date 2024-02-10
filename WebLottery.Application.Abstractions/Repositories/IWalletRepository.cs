using Models;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IWalletRepository
{
    Wallet? GetUserWallet(Guid userId);
}