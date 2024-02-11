namespace WebLottery.Application.Contracts.Currencies;

public interface ICurrencyService
{
    void CreateCurrency(string name, string abbreviation);
}