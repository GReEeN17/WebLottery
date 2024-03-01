using WebLottery.Application.Models.Pocket;

namespace WebLottery.Application.Contracts.Pocket;

public interface IPocketService
{
    Task<string> CreatePocket(PocketModel pocketModel);
    string GetPocket(int pocketId);
    Task UpdatePocket(PocketModel pocketModel);
    Task DeletePocket(int pocketId);
}