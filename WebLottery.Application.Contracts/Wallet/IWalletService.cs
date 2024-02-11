using Models;
using Models.Currencies;

namespace WebLottery.Application.Contracts.Wallets;

public interface IWalletService
{
    void CreateWallet(Guid userId);
    IEnumerable<Models.WalletCurrency.WalletCurrency> GetUserWalletCurrency(Guid userId);
}