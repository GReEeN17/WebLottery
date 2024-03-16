using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.Contracts.WalletCurrency;

public interface IWalletCurrencyService
{ 
    Task<string> CreateWalletCurrency(WalletCurrencyModel walletCurrencyModel);
    string GetWalletCurrency(int walletCurrencyId);
    Task UpdateWalletCurrency(WalletCurrencyModel walletCurrencyModel);
    Task DeleteWalletCurrency(int walletCurrencyId);
}