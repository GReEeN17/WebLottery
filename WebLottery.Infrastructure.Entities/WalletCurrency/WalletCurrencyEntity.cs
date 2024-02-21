using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Entities.Wallet;

namespace WebLottery.Infrastructure.Entities.WalletCurrency;

public class WalletCurrencyEntity : Entity
{
    public int Id { get; set; }
    public int WalletId { get; set; }
    public WalletEntity Wallet { get; set; }
    public int CurrencyId { get; set; }
    public CurrencyEntity Currency { get; set; }
    public int Amount { get; set; }
}