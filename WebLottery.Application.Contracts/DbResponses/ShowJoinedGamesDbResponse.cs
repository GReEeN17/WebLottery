using WebLottery.Application.Contracts.ServiceAbstractionsModels;

namespace WebLottery.Application.Contracts.DbResponses;

public class ShowJoinedGamesDbResponse
{
    public List<ShowJoinedGames>? JoinedGames { get; set; }
}