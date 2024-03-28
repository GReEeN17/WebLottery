using System.Net;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.ResponsesAbstractions;

namespace WebLottery.Application.Contracts.Responses;

public class EndDrawResponse : IResponse<EndDrawDbResponse>
{
    public HttpStatusCode Status { get; set; }
    public string Comments { get; set; }
    public EndDrawDbResponse? Value { get; set; }
}