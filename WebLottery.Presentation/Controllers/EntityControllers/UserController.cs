using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.User;
using WebLottery.Application.Models.User;
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
    public ActionResult<string> Login([FromBody]UserEmailLoginRequest userEmailLoginRequest)
    {
        var token = userService.LoginWithEmail(userEmailLoginRequest.Email, userEmailLoginRequest.Password);

        if (httpContextAccessor.HttpContext is null)
        {
            return BadRequest("Internal server error");
        }
        
        httpContextAccessor.HttpContext.Response.Cookies.Append("tasty-cookies", token);

        return Ok(token);
    }
}