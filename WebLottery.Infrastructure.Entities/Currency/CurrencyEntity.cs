using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.Prize;
using WebLottery.Infrastructure.Entities.WalletCurrency;

namespace WebLottery.Infrastructure.Entities.Currency;

public class CurrencyEntity : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public List<WalletCurrencyEntity> WalletCurrencies { get; set; }
    public List<PrizeEntity> Prizes { get; set; }
}