using Models.Abstractions;
using Models.Users;

namespace Models;

public class Wallet : Entity
{
    public User User { get; set; }
    public List<WalletCurrency.WalletCurrency> WalletCurrencies { get; set; }
}