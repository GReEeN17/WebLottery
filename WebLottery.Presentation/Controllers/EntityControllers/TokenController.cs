using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Responses;
using WebLottery.Infrastructure.Implementations.Jwt;
using WebLottery.Presentation.Controllers.Astractions;
using WebLottery.Presentation.Controllers.Requests;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class TokenController(IJwtProvider jwtProvider) : BaseController
{
    [HttpPost("refresh")]
    public async Task<ActionResult<AuthenticatedResponse>> Refresh([FromBody] TokenRefreshRequest tokenRefreshRequest)
    {
        
    }
}