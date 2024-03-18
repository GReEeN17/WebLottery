using WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

namespace WebLottery.Application.Contracts.ServiceAbstractionsResponses;

public class AuthenticatedResponse : Response
{
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
}