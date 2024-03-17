using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Entities;

public class CurrencyEntity : Entity
{
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public List<WalletCurrencyEntity> WalletCurrencies { get; set; }
    public List<PrizeEntity> Prizes { get; set; }
}