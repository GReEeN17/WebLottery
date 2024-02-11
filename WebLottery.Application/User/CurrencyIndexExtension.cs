namespace WebLottery.Application.Users;

public static class CurrencyIndexExtension
{
    public static int GetCurrencyIndex(this CurrencyIndex currencyIndex)
    {
        return currencyIndex switch
        {
            CurrencyIndex.Coins => 0,
            CurrencyIndex.Tokens => 1,
            _ => throw new ArgumentOutOfRangeException(nameof(currencyIndex), currencyIndex, null)
        };
    }
}