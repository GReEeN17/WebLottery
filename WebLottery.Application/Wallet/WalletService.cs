using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.WalletCurrency;
using WebLottery.Application.Contracts.Wallet;
using WebLottery.Application.Models.WalletCurrency;

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

    public WalletCurrencyModel GetUserCurrency(int userId, int currencyId)
    {
        int walletId = _walletRepository.GetWallet(userId).Result.Id;
        return _walletCurrencyService.GetUserCurrency(walletId, currencyId);
    }

    public IEnumerable<WalletCurrencyModel> GetAllUserCurrencies(int userId)
    {
        return _walletCurrencyService.GetAllUserCurrencies(userId);
    }
}