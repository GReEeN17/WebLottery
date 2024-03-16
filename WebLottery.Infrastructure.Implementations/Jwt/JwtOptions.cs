namespace WebLottery.Infrastructure.Implementations.Jwt;

public class JwtOptions
{
    public string SecretKey { get; set; }

    public int ExpiresMinutes { get; set; }
    public int RefreshTokenExpiresDays { get; set; }
}