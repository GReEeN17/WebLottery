using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IWalletCurrencyService
{ 
    Task<string> CreateWalletCurrency(WalletCurrencyModel walletCurrencyModel);
    string GetWalletCurrency(Guid walletCurrencyId);
    Task UpdateWalletCurrency(WalletCurrencyModel walletCurrencyModel);
    Task DeleteWalletCurrency(Guid walletCurrencyId);
}