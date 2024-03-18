using System.Security.Claims;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Contracts.ServiceAbstractionsResponses;
using WebLottery.Infrastructure.Implementations.Jwt;

namespace WebLottery.Application.Services;

public class TokenService(IUserService userService, IJwtProvider jwtProvider) : ITokenService
{
    public async Task<AuthenticatedResponse?> Refresh(string accessToken, string refreshToken)
    {
        var principal = jwtProvider.GetPrincipalFromExpiredToken(accessToken);
        var username = principal.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();

        if (username is null)
        {
            return null;
        }

        var user = userService.GetUser(username);
        
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
        var username = claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();

        if (username is null)
        {
            return false;
        }
        
        var user = userService.GetUser(username);
        
        if (user is null)
        {
            return false;
        }
        
        user.RefreshToken = null;
        await userService.UpdateUser(user);

        return true;
    }
}