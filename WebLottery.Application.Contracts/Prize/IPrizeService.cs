namespace WebLottery.Application.Contracts.Prizes;

public interface IPrizeService
{
    void CreatePrize(string name, string? description, int? currencyId);
}