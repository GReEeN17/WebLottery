using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.WalletCurrency;
using WebLottery.Application.Models.WalletCurrency;

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

    public WalletCurrencyModel GetUserCurrency(int walletId, int currencyId)
    {
        return _walletCurrencyRepository.GetUserCurrency(walletId, currencyId).Result;
    }

    public IEnumerable<WalletCurrencyModel> GetAllUserCurrencies(int walletId)
    {
        return _walletCurrencyRepository.GetAllUserCurrency(walletId).ToBlockingEnumerable();
    }
}