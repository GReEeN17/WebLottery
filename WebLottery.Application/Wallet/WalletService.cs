using WebLottery.Application.Contracts.Wallet;
using WebLottery.Application.Models.Wallet;

namespace WebLottery.Application.Wallet;

public class WalletService : IWalletService
{
    public Task<int> CreateWallet(WalletModel walletModel)
    {
        throw new NotImplementedException();
    }

    public string GetWallet(int walletId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateWallet(WalletModel walletModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteWallet(int walletId)
    {
        throw new NotImplementedException();
    }
}