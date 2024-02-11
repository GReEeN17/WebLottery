using Models;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IWalletRepository
{
    Task CreateWallet(Guid userId);
    Task<Guid> GetUserWallet(Guid userId);
}