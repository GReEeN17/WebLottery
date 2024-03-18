using WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

namespace WebLottery.Application.Contracts.ServiceAbstractionsResponses;

public class ShowWallet : Response
{
    public string? CurrencyName { get; set; }
    public int Amount { get; set; }
}