using System.Net;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

namespace WebLottery.Application.Contracts.ServiceAbstractionsResponses;

public class UpgradeUserToAdminResponse : IResponse<UpgradeUserToAdminDbResponse>
{
    public UpgradeUserToAdminDbResponse? Value { get; set; }
    public HttpStatusCode Status { get; set; }
    public string Comments { get; set; }
}