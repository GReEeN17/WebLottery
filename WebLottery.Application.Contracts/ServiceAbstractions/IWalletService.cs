using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IWalletService
{
    Task<string> CreateWallet(WalletModel walletModel);
    string GetWallet(Guid walletId);
    Task UpdateWallet(WalletModel walletModel);
    Task DeleteWallet(Guid walletId);
}