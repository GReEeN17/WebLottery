using System.Net;

namespace WebLottery.Application.Contracts.ResponsesAbstractions;

public interface IHttpResponse
{
    HttpStatusCode Status { get; set; }
    string Comments { get; set; }
}