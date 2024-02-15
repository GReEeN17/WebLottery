using WebLottery.Application.Models.Pocket;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IPocketRepository
{
    Task<PocketModel> CreatePocket(int userId);
    Task<PocketModel> GetPocket(int pocketId);
    Task<int> GetUserPocket(int userId);
}