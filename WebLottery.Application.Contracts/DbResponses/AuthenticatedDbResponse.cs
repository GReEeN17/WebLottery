using WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

namespace WebLottery.Application.Contracts.DbResponses;

public class AuthenticatedDbResponse
{
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
}