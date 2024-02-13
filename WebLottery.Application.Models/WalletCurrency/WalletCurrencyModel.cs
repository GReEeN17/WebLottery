using WebLottery.Application.Models.Currency;
using WebLottery.Application.Models.Wallet;

namespace WebLottery.Application.Models.WalletCurrency;

public class WalletCurrencyModel
{
    public int Id { get; set; }
    public WalletModel WalletEntity { get; set; }
    public CurrencyModel CurrencyEntity { get; set; }
    public int Amount { get; set; }
}