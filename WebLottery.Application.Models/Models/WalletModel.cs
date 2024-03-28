namespace WebLottery.Application.Models.Models;

public class WalletModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public List<WalletCurrencyModel> WalletCurrencies { get; set; }
}