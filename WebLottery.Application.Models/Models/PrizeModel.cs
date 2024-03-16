namespace WebLottery.Application.Models.Models;

public class PrizeModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? CurrencyId { get; set; }
    public CurrencyModel? Currency { get; set; }
}