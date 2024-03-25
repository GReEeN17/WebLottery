namespace WebLottery.Application.Defaults;

public static class ServiceDefaultsExtension
{
    public static Guid GetServiceDefaultCurrencyGuid(this ServiceDefaults serviceDefaults)
    {
        return serviceDefaults switch
        {
            ServiceDefaults.DefaultCurrency => Guid.Parse("dac8a590-77dc-4b7f-81f8-55c0cbec66d9"),
            ServiceDefaults.MakingDrawCurrency => Guid.Parse("dac8a590-77dc-4b7f-81f8-55c0cbec66d9"),
            _ => throw new ArgumentOutOfRangeException(nameof(serviceDefaults), serviceDefaults, null)
        };
    }
    
    public static int GetServiceDefaultMinimumAmountToJoinDraw(this ServiceDefaults serviceDefaults)
    {
        return serviceDefaults switch
        {
            ServiceDefaults.MinimumAmountToJoinDraw => 10,
            _ => throw new ArgumentOutOfRangeException(nameof(serviceDefaults), serviceDefaults, null)
        };
    }
    
    public static int GetServiceDefaultMaxPlayersAmount(this ServiceDefaults serviceDefaults)
    {
        return serviceDefaults switch
        {
            ServiceDefaults.MaxPlayersAmount => 100,
            _ => throw new ArgumentOutOfRangeException(nameof(serviceDefaults), serviceDefaults, null)
        };
    }
}