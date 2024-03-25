using System.Net;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.ResponsesAbstractions;

namespace WebLottery.Application.Contracts.Responses;

public class CreateDrawResponse : IResponse<CreateDrawDbResponse>
{
    public HttpStatusCode Status { get; set; }
    public string Comments { get; set; }
    public CreateDrawDbResponse? Value { get; set; }
}