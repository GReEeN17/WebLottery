namespace WebLottery.Application.Contracts.Wallets;

public interface IWalletService
{
    void CreateWallet(int userId);
    Models.WalletCurrency.WalletCurrency GetUserWalletCurrency(int userId, int currencyId);
    IEnumerable<Models.WalletCurrency.WalletCurrency> GetAllUserWalletCurrency(int userId);
}