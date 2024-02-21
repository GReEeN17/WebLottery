using WebLottery.Application.Models.User;
using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.Models.Wallet;

public class WalletModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserModel User { get; set; }
    private List<WalletCurrencyModel> WalletCurrencies { get; set; }
}