using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.Requests;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Presentation.Controllers.Astractions;
using WebLottery.Presentation.Controllers.Extensions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class UserController(IUserService userService, IHttpContextAccessor httpContextAccessor) : BaseController
{
    [HttpPost("register")]
    public async Task<ActionResult<RegisterDbResponse?>> Register([FromBody] UserModel userModel)
    {
        var registerResponse = await userService.Register(userModel);

        return ResponseExtension<RegisterDbResponse?>.GetResponseResult(registerResponse!);
    }

    [HttpPost("loginEmail")]
    public async Task<ActionResult<AuthenticatedDbResponse?>> Login([FromBody]UserEmailLoginRequest userEmailLoginRequest)
    {
        var authenticatedResponse = await userService.LoginWithEmail(userEmailLoginRequest);

        if (httpContextAccessor.HttpContext is null)
        {
            authenticatedResponse.Status = HttpStatusCode.InternalServerError;
            authenticatedResponse.Comments = "Internal server error";
            authenticatedResponse.Value = null;
        }
        else if (authenticatedResponse.Value?.Token is null || authenticatedResponse.Value.RefreshToken is null)
        {
            authenticatedResponse.Status = HttpStatusCode.BadRequest;
            authenticatedResponse.Comments = "Invalid client request";
            authenticatedResponse.Value = null;
        }
        else
        {
            httpContextAccessor.HttpContext.Response.Cookies.Append("tasty-cookies", authenticatedResponse.Value.Token);
        }

        return ResponseExtension<AuthenticatedDbResponse?>.GetResponseResult(authenticatedResponse!);
    }
    
    [HttpPost("loginUsername")]
    public async Task<ActionResult<AuthenticatedDbResponse?>> Login([FromBody]UserUsernameLoginRequest userUsernameLoginRequest)
    {
        var authenticatedResponse = await userService.LoginWithUsername(userUsernameLoginRequest);

        if (httpContextAccessor.HttpContext is null)
        {
            authenticatedResponse.Status = HttpStatusCode.InternalServerError;
            authenticatedResponse.Comments = "Internal server error";
            authenticatedResponse.Value = null;
        }
        else if (authenticatedResponse.Value?.Token is null || authenticatedResponse.Value.RefreshToken is null)
        {
            authenticatedResponse.Status = HttpStatusCode.BadRequest;
            authenticatedResponse.Comments = "Invalid client request";
            authenticatedResponse.Value = null;
        }
        else
        {
            httpContextAccessor.HttpContext.Response.Cookies.Append("tasty-cookies", authenticatedResponse.Value.Token);
        }

        return ResponseExtension<AuthenticatedDbResponse?>.GetResponseResult(authenticatedResponse!);
    }

    [Authorize]
    [HttpGet("showWallet")]
    public ActionResult<ShowWalletDbResponse?> ShowWallet()
    {
        var showWalletResponse = userService.ShowWallet(User.Claims);

        return ResponseExtension<ShowWalletDbResponse?>.GetResponseResult(showWalletResponse!);
    }

    [Authorize]
    [HttpPut("upgradeUserToAdmin")]
    public async Task<ActionResult<UpgradeUserToAdminDbResponse?>> UpgradeUserToAdmin([FromBody] Guid userId)
    {
        var upgradeUserToAdminResponse = await userService.UpgradeUserToAdmin(User.Claims, userId);

        return ResponseExtension<UpgradeUserToAdminDbResponse?>.GetResponseResult(upgradeUserToAdminResponse!);
    }

    [Authorize]
    [HttpPost("createAdmin")]
    public async Task<ActionResult<CreateAdminDbResponse?>> CreateAdmin([FromBody] UserModel userModel)
    {
        var createAdminResponse = await userService.CreateAdmin(User.Claims, userModel);
        
        return ResponseExtension<CreateAdminDbResponse?>.GetResponseResult(createAdminResponse!);
    }
}