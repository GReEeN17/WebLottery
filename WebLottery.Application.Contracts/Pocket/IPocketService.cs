using WebLottery.Application.Models.Pocket;

namespace WebLottery.Application.Contracts.Pocket;

public interface IPocketService
{
    Task<string> CreatePocket(int userId);
    Task<string> GetPocket(int pocketId);
    Task UpdatePocket(int pocketId, int? userId);
    Task DeletePocket(int pocketId);
}