using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.Contracts.WalletCurrency;

public interface IWalletCurrencyService
{ 
    Task<int> CreateWalletCurrency(int walletId, int currencyId);
    Task<WalletCurrencyModel> GetWalletCurrency(int walletCurrencyId);
    Task UpdateWalletCurrency(int walletCurrencyId, int? walletId, int? currencyId);
    Task DeleteWalletCurrency(int walletCurrencyId);
}