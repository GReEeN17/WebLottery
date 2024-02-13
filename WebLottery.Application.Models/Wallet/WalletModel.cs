using WebLottery.Application.Models.User;

namespace WebLottery.Application.Models.Wallet;

public class WalletModel
{
    public int Id { get; set; }
    public UserModel UserEntity { get; set; }
    public List<WalletCurrency.WalletCurrencyModel> WalletCurrencies { get; set; }
}