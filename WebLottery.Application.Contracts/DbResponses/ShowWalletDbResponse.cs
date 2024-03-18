using WebLottery.Application.Contracts.ServiceAbstractionsResponses;

namespace WebLottery.Application.Contracts.DbResponses;

public class ShowWalletDbResponse
{
    public List<ShowWallet>? Wallet { get; set; }
}