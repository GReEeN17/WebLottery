namespace WebLottery.Application.Models.Models;

public class WalletCurrencyModel
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public Guid WalletId { get; set; }
    public WalletModel? Wallet { get; set; }
    public Guid CurrencyId { get; set; }
    public CurrencyModel? Currency { get; set; }
}