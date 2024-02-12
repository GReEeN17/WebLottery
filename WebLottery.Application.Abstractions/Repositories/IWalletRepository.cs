namespace WebLottery.Application.Abstractions.Repositories;

public interface IWalletRepository
{
    Task CreateWallet(int userId);
    Task<int> GetUserWallet(int userId);
}