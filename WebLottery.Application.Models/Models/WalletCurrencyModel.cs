namespace WebLottery.Application.Models.Models;

public class WalletCurrencyModel
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public int WalletId { get; set; }
    public WalletModel? Wallet { get; set; }
    public int CurrencyId { get; set; }
    public CurrencyModel? Currency { get; set; }
}