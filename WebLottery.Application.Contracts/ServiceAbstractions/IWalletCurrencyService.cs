using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IWalletCurrencyService
{ 
    Task<string> CreateWalletCurrency(WalletCurrencyModel walletCurrencyModel);
    string GetWalletCurrency(int walletCurrencyId);
    Task UpdateWalletCurrency(WalletCurrencyModel walletCurrencyModel);
    Task DeleteWalletCurrency(int walletCurrencyId);
}