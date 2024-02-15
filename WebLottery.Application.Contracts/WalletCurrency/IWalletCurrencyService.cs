using WebLottery.Application.Models.Currency;

namespace WebLottery.Application.Contracts.WalletCurrency;

public interface IWalletCurrencyService
{ 
    void CreateWalletCurrency(int walletId, int currencyId);
    Tuple<CurrencyModel, int> GetUserCurrency(int walletId, int currencyId);
    IEnumerable<Tuple<CurrencyModel, int>> GetAllUserCurrencies(int walletId);
}