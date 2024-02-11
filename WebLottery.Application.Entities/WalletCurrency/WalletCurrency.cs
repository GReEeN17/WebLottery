using Models.Abstractions;
using Models.Currencies;

namespace Models.WalletCurrency;

public class WalletCurrency : Entity
{
    public Wallet Wallet { get; set; }
    public Currency Currency { get; set; }
    public int amount { get; set; }
}