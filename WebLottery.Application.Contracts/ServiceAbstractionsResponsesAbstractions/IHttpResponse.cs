using System.Net;

namespace WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

public interface IHttpResponse
{
    HttpStatusCode Status { get; set; }
    string Comments { get; set; }
}