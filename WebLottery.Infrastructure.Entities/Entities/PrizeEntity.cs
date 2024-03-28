using System.ComponentModel.DataAnnotations.Schema;
using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Entities.Entities;

public class PrizeEntity : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    [ForeignKey("Currency")]
    public Guid CurrencyId { get; set; }
    public CurrencyEntity? Currency { get; set; }
    public List<DrawEntity> Draws { get; set; }
    public int Amount { get; set; }
}