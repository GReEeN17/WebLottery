using WebLottery.Application.Contracts.ServiceAbstractionsModels;

namespace WebLottery.Application.Contracts.DbResponses;

public class ShowWalletDbResponse
{
    public List<ShowWallet>? Wallet { get; set; }
}