using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Entities;

public class WalletEntity : Entity
{
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public List<WalletCurrencyEntity> WalletCurrencies { get; set; }
}