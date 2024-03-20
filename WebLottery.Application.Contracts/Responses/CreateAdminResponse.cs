using System.Net;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.ResponsesAbstractions;

namespace WebLottery.Application.Contracts.Responses;

public class CreateAdminResponse : IResponse<CreateAdminDbResponse>
{
    public CreateAdminDbResponse? Value { get; set; }
    public HttpStatusCode Status { get; set; }
    public string Comments { get; set; }
}