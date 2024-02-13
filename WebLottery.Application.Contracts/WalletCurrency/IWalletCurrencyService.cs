namespace WebLottery.Application.Contracts.WalletCurrency;

public interface IWalletCurrencyService
{ 
    void CreateWalletCurrency(int walletId, int currencyId);
    Models.WalletCurrency.WalletCurrencyModel GetUserWalletCurrency(int walletId, int currencyId);
    IEnumerable<Models.WalletCurrency.WalletCurrencyModel> GetAllUserWalletCurrency(int walletId);
}