using WebLottery.Application.Models.Currency;
using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.Contracts.WalletCurrency;

public interface IWalletCurrencyService
{ 
    void CreateWalletCurrency(int walletId, int currencyId);
    WalletCurrencyModel GetUserCurrency(int walletId, int currencyId);
    IEnumerable<WalletCurrencyModel> GetAllUserCurrencies(int walletId);
}