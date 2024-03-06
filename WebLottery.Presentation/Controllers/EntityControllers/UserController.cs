using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.User;
using WebLottery.Application.Models.User;
using WebLottery.Presentation.Controllers.Astractions;
using WebLottery.Presentation.Controllers.Requests;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class UserController(IUserService userService) : BaseController
{
    [HttpPost("register")]
    public ActionResult<string> Register([FromBody] UserModel userModel)
    {
        var jsonUser = userService.Register(userModel).Result;
        
        if (String.IsNullOrEmpty(jsonUser))
        {
            return BadRequest("id is empty");
        }

        return Ok(jsonUser);
    }

    [HttpPost("loginEmail")]
    public ActionResult<string> Login([FromBody] UserEmailLoginRequest userEmailLoginRequest)
    {
        var jsonResponse = userService.LoginWithEmail(userEmailLoginRequest.Email, userEmailLoginRequest.Password).Result;

        return Ok(jsonResponse);
    }
}