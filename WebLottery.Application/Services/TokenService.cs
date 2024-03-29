using System.Net;
using System.Security.Claims;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.Requests;
using WebLottery.Application.Contracts.Responses;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Infrastructure.Implementations.Jwt;

namespace WebLottery.Application.Services;

public class TokenService(IUserService userService, IJwtProvider jwtProvider) : ITokenService
{
    public async Task<AuthenticatedResponse?> Refresh(TokenRefreshRequest tokenRefreshRequest)
    {
        var principal = jwtProvider.GetPrincipalFromExpiredToken(tokenRefreshRequest.AccessToken!);
        var username = principal.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();

        if (username is null)
        {
            return null;
        }

        var user = userService.GetUser(username);
        
        if (user is null || user.RefreshToken != tokenRefreshRequest.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return null;
        }
        
        var newAccessToken = jwtProvider.GenerateAccessToken(principal.Claims);
        var newRefreshToken = jwtProvider.GenerateRefreshToken();
        
        user.RefreshToken = newRefreshToken;
        await userService.UpdateUser(user);
        
        AuthenticatedDbResponse authenticatedDbResponse = new AuthenticatedDbResponse
        {
            Token = newAccessToken,
            RefreshToken = newRefreshToken
        };

        AuthenticatedResponse authenticatedResponse = new AuthenticatedResponse
        {
            Status = HttpStatusCode.OK,
            Comments = "Ok",
            Value = authenticatedDbResponse
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