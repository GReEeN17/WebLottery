using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.WalletCurrency;
using WebLottery.Application.Contracts.Wallet;

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

    public Models.WalletCurrency.WalletCurrencyModel GetUserWalletCurrency(int userId, int currencyId)
    {
        int walletId = _walletRepository.GetUserWallet(userId).Result;
        return _walletCurrencyService.GetUserWalletCurrency(walletId, currencyId);
    }

    public IEnumerable<Models.WalletCurrency.WalletCurrencyModel> GetAllUserWalletCurrency(int userId)
    {
        int walletId = _walletRepository.GetUserWallet(userId).Result;
        return _walletCurrencyService.GetAllUserWalletCurrency(walletId);    
    }
}