using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.WalletCurrency;
using WebLottery.Application.Contracts.Wallets;

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


    public void CreateWallet(Guid userId)
    {
        _walletRepository.CreateWallet(userId);
    }

    public IEnumerable<Models.WalletCurrency.WalletCurrency> GetUserWalletCurrency(Guid userId)
    { 
        Guid walletId = _walletRepository.GetUserWallet(userId).Result;
        return _walletCurrencyService.GetUserWalletCurrency(walletId);
    }
}