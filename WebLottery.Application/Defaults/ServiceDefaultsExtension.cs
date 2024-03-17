namespace WebLottery.Application.Defaults;

public static class ServiceDefaultsExtension
{
    public static Guid GetServiceDefault(this ServiceDefaults serviceDefaults)
    {
        return serviceDefaults switch
        {
            ServiceDefaults.DefaultCurrency => Guid.Parse("dac8a590-77dc-4b7f-81f8-55c0cbec66d9"),
            _ => throw new ArgumentOutOfRangeException(nameof(serviceDefaults), serviceDefaults, null)
        };
    }
}