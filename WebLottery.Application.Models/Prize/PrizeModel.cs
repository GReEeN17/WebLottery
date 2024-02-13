using WebLottery.Application.Models.Currency;

namespace WebLottery.Application.Models.Prize;

public class PrizeModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CurrencyModel CurrencyEntity { get; set; }
}