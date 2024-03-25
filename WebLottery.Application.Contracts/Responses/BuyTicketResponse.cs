using System.Net;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.ResponsesAbstractions;

namespace WebLottery.Application.Contracts.Responses;

public class BuyTicketResponse : IResponse<BuyTicketDbResponse>
{
    public HttpStatusCode Status { get; set; }
    public string Comments { get; set; }
    public BuyTicketDbResponse? Value { get; set; }
}