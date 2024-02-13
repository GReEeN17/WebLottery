using Models.Abstractions;
using Models.Currency;

namespace Models.Prize;

public class PrizeEntity : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public CurrencyEntity CurrencyEntity { get; set; }
}