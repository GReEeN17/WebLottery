using Models.Abstractions;
using Models.User;

namespace Models;

public class WalletEntity : Entity
{
    public UserEntity UserEntity { get; set; }
    public List<WalletCurrency.WalletCurrencyEntity> WalletCurrencies { get; set; }
}