using Models.Currencies;

namespace WebLottery.Application.Contracts.WalletCurrency;

public interface IWalletCurrencyService
{ 
    void CreateWalletCurrency(Guid walletId, Guid currencyId);
    IEnumerable<Models.WalletCurrency.WalletCurrency> GetUserWalletCurrency(Guid walletId);
}