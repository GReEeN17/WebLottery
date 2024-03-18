using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Contracts.ServiceAbstractionsResponses;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.EntitiesExtensions;
using WebLottery.Presentation.Controllers.Astractions;
using WebLottery.Presentation.Controllers.Requests;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class UserController(IUserService userService, IHttpContextAccessor httpContextAccessor) : BaseController
{
    [HttpPost("register")]
    public async Task<ActionResult<string>> Register([FromBody] UserModel userModel)
    {
        var jsonUser = await userService.Register(userModel);
        
        if (String.IsNullOrEmpty(jsonUser))
        {
            return BadRequest("id is empty");
        }

        return Ok(jsonUser);
    }

    [HttpPost("loginEmail")]
    public async Task<ActionResult<AuthenticatedResponse>> Login([FromBody]UserEmailLoginRequest userEmailLoginRequest)
    {
        if (userEmailLoginRequest is null)
        {
            return BadRequest("invalid client request");
        }
        
        var authenticatedResponse = await userService.LoginWithEmail(userEmailLoginRequest.Email, userEmailLoginRequest.Password);

        if (authenticatedResponse is null)
        {
            return BadRequest("Password or email is wrong");
        }

        if (authenticatedResponse.Token is null || authenticatedResponse.RefreshToken is null)
        {
            return BadRequest("Internal server error");
        }

        if (httpContextAccessor.HttpContext is null)
        {
            return BadRequest("Internal server error");
        }
        
        httpContextAccessor.HttpContext.Response.Cookies.Append("tasty-cookies", authenticatedResponse.Token);

        return Ok(authenticatedResponse);
    }
    
    [HttpPost("loginUsername")]
    public async Task<ActionResult<AuthenticatedResponse>> Login([FromBody]UserUsernameLoginRequest userUsernameLoginRequest)
    {
        if (userUsernameLoginRequest is null)
        {
            return BadRequest("invalid client request");
        }
        
        var authenticatedResponse = await userService.LoginWithUsername(userUsernameLoginRequest.Username, userUsernameLoginRequest.Password);

        if (authenticatedResponse is null)
        {
            return BadRequest("Password or username is wrong");
        }

        if (authenticatedResponse.Token is null || authenticatedResponse.RefreshToken is null)
        {
            return BadRequest("Internal server error");
        }

        if (httpContextAccessor.HttpContext is null)
        {
            return BadRequest("Internal server error");
        }
        
        httpContextAccessor.HttpContext.Response.Cookies.Append("tasty-cookies", authenticatedResponse.Token);

        return Ok(authenticatedResponse);
    }

    [Authorize]
    [HttpGet("showWallet")]
    public ActionResult<ShowWallet> ShowWallet()
    {
        var showWalletResponse = userService.ShowWallet(User.Claims);

        if (showWalletResponse is null)
        {
            return BadRequest("Invalid client request");
        }

        return Ok(showWalletResponse);
    }

    [Authorize]
    [HttpPut("upgradeUserToAdmin")]
    public async Task<ActionResult<string>> UpgradeUserToAdmin([FromBody] Guid userId)
    {
        var upgradeUserToAdminResponse = await userService.UpgradeUserToAdmin(User.Claims, userId);

        var result = string.Empty;

        switch (upgradeUserToAdminResponse.Status)
        {
            case 400:
                return BadRequest(upgradeUserToAdminResponse.Comments);
            case 403:
                return Forbid(upgradeUserToAdminResponse.Comments);
            case 200:
                break;
        }

        return Ok(upgradeUserToAdminResponse.UserRole!.Value.GetUserRole());
    }
}