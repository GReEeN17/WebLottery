using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Entities;

public class WalletCurrencyEntity : Entity
{
    public int Id { get; set; }
    [ForeignKey("Wallet")]
    public int WalletId { get; set; }
    public WalletEntity Wallet { get; set; }
    [ForeignKey("Currency")]
    public int CurrencyId { get; set; }
    public CurrencyEntity Currency { get; set; }
    public int Amount { get; set; }
}