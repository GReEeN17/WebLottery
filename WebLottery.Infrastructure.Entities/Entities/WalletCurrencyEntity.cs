using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Entities;

public class WalletCurrencyEntity : Entity
{
    [ForeignKey("Wallet")]
    public Guid WalletId { get; set; }
    public WalletEntity Wallet { get; set; }
    [ForeignKey("Currency")]
    public Guid CurrencyId { get; set; }
    public CurrencyEntity Currency { get; set; }
    public int Amount { get; set; }
}