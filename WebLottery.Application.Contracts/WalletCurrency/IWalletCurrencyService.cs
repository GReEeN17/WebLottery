using Models.Currencies;

namespace WebLottery.Application.Contracts.WalletCurrency;

public interface IWalletCurrencyService
{ 
    void CreateWalletCurrency(int walletId, int currencyId);
    Models.WalletCurrency.WalletCurrency GetUserWalletCurrency(int walletId, int currencyId);
    IEnumerable<Models.WalletCurrency.WalletCurrency> GetAllUserWalletCurrency(int walletId);
}