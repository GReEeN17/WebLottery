namespace WebLottery.Infrastructure.Implementations.Jwt;

public class JwtOptions
{
    public string SecretKey { get; set; } = "SUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUDAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAETUUUUUUUUUUUUUUUUUPROGUUUUUUU";

    public int ExpiresHours { get; set; } = 12;
}