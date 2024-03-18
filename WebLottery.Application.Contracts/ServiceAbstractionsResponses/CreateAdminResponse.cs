using System.Net;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

namespace WebLottery.Application.Contracts.ServiceAbstractionsResponses;

public class CreateAdminResponse : IResponse<CreateAdminDbResponse>
{
    public CreateAdminDbResponse? Value { get; set; }
    public HttpStatusCode Status { get; set; }
    public string Comments { get; set; }
}