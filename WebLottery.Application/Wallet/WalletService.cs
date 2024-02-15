using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.WalletCurrency;
using WebLottery.Application.Contracts.Wallet;
using WebLottery.Application.Models.Currency;

namespace WebLottery.Application.Wallet;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;
    private readonly IWalletCurrencyService _walletCurrencyService;

    public WalletService(
        IWalletRepository walletRepository,
        IWalletCurrencyService walletCurrencyService)
    {
        _walletRepository = walletRepository;
        _walletCurrencyService = walletCurrencyService;
    }


    public void CreateWallet(int userId)
    {
        _walletRepository.CreateWallet(userId);
    }

    public Tuple<CurrencyModel, int> GetUserCurrency(int userId, int currencyId)
    {
        int walletId = _walletRepository.GetUserWallet(userId).Result;
        return _walletCurrencyService.GetUserWalletCurrency(walletId, currencyId);
    }

    public IEnumerable<Tuple<CurrencyModel, int>> GetAllUserCurrencies(int userId)
    {
        int walletId = _walletRepository.GetUserWallet(userId).Result;
        return _walletCurrencyService.GetAllUserWalletCurrency(walletId);    
    }
}