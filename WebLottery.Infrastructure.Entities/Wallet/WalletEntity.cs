using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Infrastructure.Entities.Wallet;

public class WalletEntity : Entity
{
    public int Id { get; set; }
    public UserEntity User { get; set; }
    public List<WalletCurrency.WalletCurrencyEntity> WalletCurrencies { get; set; }
}