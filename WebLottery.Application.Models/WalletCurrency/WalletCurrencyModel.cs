namespace WebLottery.Application.Models.WalletCurrency;

public class WalletCurrencyModel
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public int WalletId { get; set; }
    public int CurrencyId { get; set; }
}