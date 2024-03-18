using System.Security.Claims;
using WebLottery.Application.Contracts.ServiceAbstractionsResponses;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface ITokenService
{
    Task<AuthenticatedResponse?> Refresh(string accessToken, string refreshToken);
    Task<bool> Revoke(IEnumerable<Claim> claims);
}