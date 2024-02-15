using WebLottery.Application.Models.Currency;

namespace WebLottery.Application.Contracts.Wallet;

public interface IWalletService
{
    void CreateWallet(int userId);
    Tuple<CurrencyModel, int> GetUserCurrency(int userId, int currencyId);
    IEnumerable<Tuple<CurrencyModel, int>> GetAllUserCurrencies(int userId);
}