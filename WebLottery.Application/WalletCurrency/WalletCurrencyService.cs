using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Currency;
using WebLottery.Application.Contracts.WalletCurrency;
using WebLottery.Application.Models.Currency;
using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.WalletCurrency;

public class WalletCurrencyService : IWalletCurrencyService
{
    private readonly IWalletCurrencyRepository _walletCurrencyRepository;
    private readonly ICurrencyService _currencyService;

    public WalletCurrencyService(
        IWalletCurrencyRepository walletCurrencyRepository,
        ICurrencyService currencyService)
    {
        _walletCurrencyRepository = walletCurrencyRepository;
        _currencyService = currencyService;
    }
    
    public void CreateWalletCurrency(int walletId, int currencyId)
    {
        _walletCurrencyRepository.CreateWalletCurrency(walletId, currencyId);
    }

    public Tuple<CurrencyModel, int> GetUserCurrency(int walletId, int currencyId)
    {
        int amount = _walletCurrencyRepository.GetUserWalletCurrency(walletId, currencyId).Result.Amount;
        CurrencyModel currencyModel = _currencyService.GetCurrency(currencyId);
        
        return new Tuple<CurrencyModel, int>(currencyModel, amount);
    }

    public IEnumerable<Tuple<CurrencyModel, int>> GetAllUserCurrencies(int walletId)
    {
        IEnumerable<WalletCurrencyModel> walletCurrencyModels =
            _walletCurrencyRepository.GetAllUserWalletCurrency(walletId).ToBlockingEnumerable();

        foreach (WalletCurrencyModel walletCurrencyModel in walletCurrencyModels)
        {
            walletCurrencyModel.
        }
    }
}