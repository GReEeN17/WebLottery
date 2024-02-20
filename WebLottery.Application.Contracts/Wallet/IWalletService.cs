using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.Contracts.Wallet;

public interface IWalletService
{
    void CreateWallet(int userId);
    WalletCurrencyModel GetUserCurrency(int userId, int currencyId);
    IEnumerable<WalletCurrencyModel> GetAllUserCurrencies(int userId);
}