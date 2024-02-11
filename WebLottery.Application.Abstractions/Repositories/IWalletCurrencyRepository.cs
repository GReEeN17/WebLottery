using Models.Currencies;
using Models.WalletCurrency;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IWalletCurrencyRepository
{
    Task CreateWalletCurrency(Guid walletId, Guid currencyId);
    IAsyncEnumerable<WalletCurrency> GetWalletCurrency(Guid walletId);
}