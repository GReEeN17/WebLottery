namespace WebLottery.Application.Abstractions.Repositories;

public interface IPocketRepository
{
    Task CreatePocket(int userId);
    Task<int> GetUserPocket(int userId);
}