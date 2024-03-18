using WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;

namespace WebLottery.Application.Contracts.ServiceAbstractionsResponses;

public class ShowWalletResponse : Response
{
    public List<ShowWallet>? Wallet { get; set; }
}