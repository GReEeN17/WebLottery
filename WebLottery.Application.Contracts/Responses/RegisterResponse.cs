using System.Net;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.ResponsesAbstractions;

namespace WebLottery.Application.Contracts.Responses;

public class RegisterResponse : IResponse<RegisterDbResponse>
{
    public HttpStatusCode Status { get; set; }
    public string Comments { get; set; }
    public RegisterDbResponse? Value { get; set; }
}