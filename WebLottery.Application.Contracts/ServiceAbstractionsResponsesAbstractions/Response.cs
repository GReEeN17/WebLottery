namespace WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

public class Response : IResponse
{
    public int Status { get; set; }
    public string Comments { get; set; }
}