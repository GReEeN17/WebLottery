using System.Security.Claims;
using WebLottery.Application.Contracts.Requests;
using WebLottery.Application.Contracts.Responses;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface ITokenService
{
    Task<AuthenticatedResponse?> Refresh(TokenRefreshRequest tokenRefreshRequest);
    Task<bool> Revoke(IEnumerable<Claim> claims);
}