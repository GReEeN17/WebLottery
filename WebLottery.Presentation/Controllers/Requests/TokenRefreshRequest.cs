namespace WebLottery.Presentation.Controllers.Requests;

public class TokenRefreshRequest
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}