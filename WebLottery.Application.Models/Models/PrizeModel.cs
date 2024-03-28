namespace WebLottery.Application.Models.Models;

public class PrizeModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? CurrencyId { get; set; }
    public CurrencyModel? Currency { get; set; }
    public int Amount { get; set; }
}