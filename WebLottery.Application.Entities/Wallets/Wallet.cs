using Models.Abstractions;
using Models.Currencies;

namespace Models;

public class Wallet : Entity
{
    public Guid WalletId { get; set; }
    public int Amount { get; set; }
    public Currency Currency { get; set; }
}