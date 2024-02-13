using Models.Abstractions;
using Models.Currency;

namespace Models.WalletCurrency;

public class WalletCurrencyEntity : Entity
{
    public WalletEntity WalletEntity { get; set; }
    public CurrencyEntity CurrencyEntity { get; set; }
    public int Amount { get; set; }
}