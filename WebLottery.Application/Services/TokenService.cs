using System.Security.Claims;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Contracts.ServiceAbstractionsExtensions;
using WebLottery.Infrastructure.Implementations.Jwt;

namespace WebLottery.Application.Services;

public class TokenService(IUserService userService, IJwtProvider jwtProvider) : ITokenService
{
    public async Task<AuthenticatedResponse?> Refresh(string accessToken, string refreshToken)
    {
        var principal = jwtProvider.GetPrincipalFromExpiredToken(accessToken);
        var stringUserId = principal.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();

        if (stringUserId is null)
        {
            return null;
        }
        
        var userId = int.Parse(stringUserId);

        var user = userService.GetUser(userId);
        
        if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return null;
        }
        
        var newAccessToken = jwtProvider.GenerateAccessToken(principal.Claims);
        var newRefreshToken = jwtProvider.GenerateRefreshToken();
        
        user.RefreshToken = newRefreshToken;
        await userService.UpdateUser(user);
        
        AuthenticatedResponse authenticatedResponse = new AuthenticatedResponse
        {
            Token = newAccessToken,
            RefreshToken = newRefreshToken
        };
        
        return authenticatedResponse;
    }

    public async Task<bool> Revoke(IEnumerable<Claim> claims)
    {
        var stringUserId = claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();
        
        if (stringUserId is null)
        {
            return false;
        }
        
        var userId = int.Parse(stringUserId);
        
        var user = userService.GetUser(userId);
        
        if (user is null)
        {
            return false;
        }
        
        user.RefreshToken = null;
        await userService.UpdateUser(user);

        return true;
    }
}