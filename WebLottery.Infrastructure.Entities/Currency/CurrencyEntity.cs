using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Currency;

public class CurrencyEntity : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
}