namespace WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

public interface IResponse
{
    int Status { get; set; }
    string Comments { get; set; }
}