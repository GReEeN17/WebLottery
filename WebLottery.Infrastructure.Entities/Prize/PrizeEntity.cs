using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Entities.Draw;

namespace WebLottery.Infrastructure.Entities.Prize;

public class PrizeEntity : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CurrencyEntity? Currency { get; set; }
    public List<DrawEntity> Draws { get; set; }
}