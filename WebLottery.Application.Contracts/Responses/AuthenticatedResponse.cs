using System.Net;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.ResponsesAbstractions;

namespace WebLottery.Application.Contracts.Responses;

public class AuthenticatedResponse : IResponse<AuthenticatedDbResponse>
{
    public HttpStatusCode Status { get; set; }
    public string Comments { get; set; }
    public AuthenticatedDbResponse? Value { get; set; }
}