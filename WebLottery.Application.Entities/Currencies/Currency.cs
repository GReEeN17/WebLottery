using Models.Abstractions;

namespace Models.Currencies;

public class Currency : Entity
{
    public Guid CurrencyId { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
}