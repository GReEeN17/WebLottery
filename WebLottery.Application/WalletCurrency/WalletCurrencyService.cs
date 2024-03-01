using WebLottery.Application.Contracts.WalletCurrency;
using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.WalletCurrency;

public class WalletCurrencyService : IWalletCurrencyService
{
    public Task<int> CreateWalletCurrency(WalletCurrencyModel walletCurrencyModel)
    {
        throw new NotImplementedException();
    }

    public string GetWalletCurrency(int walletCurrencyId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateWalletCurrency(WalletCurrencyModel walletCurrencyModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteWalletCurrency(int walletCurrencyId)
    {
        throw new NotImplementedException();
    }
}