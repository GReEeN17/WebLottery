namespace WebLottery.Application.Contracts.Requests;

public class UserEmailLoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}