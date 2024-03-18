using System.Net;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

namespace WebLottery.Application.Contracts.ServiceAbstractionsResponses;

public class AuthenticatedResponse : IResponse<AuthenticatedDbResponse>
{
    public HttpStatusCode Status { get; set; }
    public string Comments { get; set; }
    public AuthenticatedDbResponse? Value { get; set; }
}