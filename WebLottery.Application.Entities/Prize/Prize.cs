using Models.Abstractions;
using Models.Currencies;

namespace Models.Prizes;

public class Prize : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Currency Currency { get; set; }
}