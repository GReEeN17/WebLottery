using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.WalletCurrency;

namespace WebLottery.Application.WalletCurrency;

public class WalletCurrencyService : IWalletCurrencyService
{
    private readonly IWalletCurrencyRepository _walletCurrencyRepository;

    public WalletCurrencyService(
        IWalletCurrencyRepository walletCurrencyRepository)
    {
        _walletCurrencyRepository = walletCurrencyRepository;
    }

    public void CreateWalletCurrency(int walletId, int currencyId)
    {
        _walletCurrencyRepository.CreateWalletCurrency(walletId, currencyId);
    }

    public Models.WalletCurrency.WalletCurrency GetUserWalletCurrency(int walletId, int currencyId)
    {
        return _walletCurrencyRepository.GetUserWalletCurrency(walletId, currencyId).Result;
    }

    public IEnumerable<Models.WalletCurrency.WalletCurrency> GetAllUserWalletCurrency(int walletId)
    {
        return _walletCurrencyRepository.GetAllUserWalletCurrency(walletId).ToBlockingEnumerable();
    }
}