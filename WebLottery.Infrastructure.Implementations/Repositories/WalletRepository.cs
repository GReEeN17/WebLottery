using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Models.Wallet;

namespace WebLottery.Infrastructure.Implementations.Repositories;

public class WalletRepository : IWalletRepository
{
    public Task<WalletModel> CreateWallet(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<WalletModel> GetWallet(int userId)
    {
        throw new NotImplementedException();
    }
}