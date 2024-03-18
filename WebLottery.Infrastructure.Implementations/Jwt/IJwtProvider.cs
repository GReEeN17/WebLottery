using System.Security.Claims;

namespace WebLottery.Infrastructure.Implementations.Jwt;

public interface IJwtProvider
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    int GetRefreshTokenExpiryDays();
}