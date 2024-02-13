using Models.Abstractions;

namespace Models.Currency;

public class CurrencyEntity : Entity
{
    public string Name { get; set; }
    public string Abbreviation { get; set; }
}