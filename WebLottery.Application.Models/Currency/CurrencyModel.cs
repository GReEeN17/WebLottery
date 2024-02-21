using WebLottery.Application.Models.Prize;
using WebLottery.Application.Models.WalletCurrency;

namespace WebLottery.Application.Models.Currency;

public class CurrencyModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public List<WalletCurrencyModel> WalletCurrencies { get; set; }
    public List<PrizeModel> Prizes { get; set; }
}