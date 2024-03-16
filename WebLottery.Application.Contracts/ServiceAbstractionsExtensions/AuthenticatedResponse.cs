namespace WebLottery.Application.Contracts.ServiceAbstractionsExtensions;

public class AuthenticatedResponse
{
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
}