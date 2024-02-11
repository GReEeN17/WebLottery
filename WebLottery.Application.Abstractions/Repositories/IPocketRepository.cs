using Models.Pockets;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IPocketRepository
{
    Task CreatePocket();
    Task<Pocket> GetUserPocket(int userId);
}