namespace WebLottery.Application.Contracts.Wallet;

public interface IWalletService
{
    void CreateWallet(int userId);
    Models.WalletCurrency.WalletCurrencyModel GetUserWalletCurrency(int userId, int currencyId);
    IEnumerable<Models.WalletCurrency.WalletCurrencyModel> GetAllUserWalletCurrency(int userId);
}