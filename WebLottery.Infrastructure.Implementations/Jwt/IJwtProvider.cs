using System.Security.Claims;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Infrastructure.Implementations.Jwt;

public interface IJwtProvider
{
    string GenerateAccessToken(UserEntity userEntity);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    int GetRefreshTokenExpiryDays();
}