using System.Net;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.ResponsesAbstractions;

namespace WebLottery.Application.Contracts.Responses;

public class ShowJoinedGamesResponse : IResponse<ShowJoinedGamesDbResponse>
{
    public HttpStatusCode Status { get; set; }
    public string Comments { get; set; }
    public ShowJoinedGamesDbResponse? Value { get; set; }
}