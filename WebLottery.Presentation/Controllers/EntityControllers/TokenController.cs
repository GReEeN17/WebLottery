using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Contracts.ServiceAbstractionsExtensions;
using WebLottery.Presentation.Controllers.Astractions;
using WebLottery.Presentation.Controllers.Requests;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class TokenController(ITokenService tokenService, IHttpContextAccessor httpContextAccessor) : BaseController
{
    [HttpPost("refresh")]
    public async Task<ActionResult<AuthenticatedResponse>> Refresh([FromBody] TokenRefreshRequest tokenRefreshRequest)
    {
        if (tokenRefreshRequest.AccessToken is null || tokenRefreshRequest.RefreshToken is null)
        {
            return BadRequest("Invalid client request");
        }

        var authenticatedResponse =
            await tokenService.Refresh(tokenRefreshRequest.AccessToken, tokenRefreshRequest.RefreshToken);

        if (authenticatedResponse is null || authenticatedResponse.Token is null || authenticatedResponse.RefreshToken is null)
        {
            return BadRequest("Invalid client request");
        }
        
        if (httpContextAccessor.HttpContext is null)
        {
            return BadRequest("Internal server error");
        }
        
        httpContextAccessor.HttpContext.Response.Cookies.Append("tasty-cookies", authenticatedResponse.Token);

        return Ok(authenticatedResponse);
    }
    
    [Authorize]
    [HttpPost("revoke")]
    public async Task<ActionResult> Revoke()
    {
        var response = await tokenService.Revoke(User.Claims);
        
        if (!response)
        {
            return BadRequest("Invalid client request");
        }
        
        return NoContent();
    }
}