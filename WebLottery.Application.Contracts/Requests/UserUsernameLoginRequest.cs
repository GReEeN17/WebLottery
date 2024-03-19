namespace WebLottery.Application.Contracts.Requests;

public class UserUsernameLoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}