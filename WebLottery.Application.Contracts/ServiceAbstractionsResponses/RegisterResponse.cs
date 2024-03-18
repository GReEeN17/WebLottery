using System.Net;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

namespace WebLottery.Application.Contracts.ServiceAbstractionsResponses;

public class RegisterResponse : IResponse<RegisterDbResponse>
{
    public HttpStatusCode Status { get; set; }
    public string Comments { get; set; }
    public RegisterDbResponse? Value { get; set; }
}