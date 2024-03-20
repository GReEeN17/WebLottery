namespace WebLottery.Application.Contracts.ServiceAbstractionsModels;

public class ShowJoinedGames
{
    public Guid DrawId { get; set; }
    public int BoughtTicketsAmount { get; set; }
    public List<int>? LuckyNumbers { get; set; }
}