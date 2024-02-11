using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Currencies;
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

    public void CreateWalletCurrency(Guid walletId, Guid currencyId)
    {
        _walletCurrencyRepository.CreateWalletCurrency(walletId, currencyId);
    }

    public IEnumerable<Models.WalletCurrency.WalletCurrency> GetUserWalletCurrency(Guid walletId)
    {
        return _walletCurrencyRepository.GetWalletCurrency(walletId).ToBlockingEnumerable();
    }
}