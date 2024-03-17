using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IPocketService
{
    Task<string> CreatePocket(PocketModel pocketModel);
    string GetPocket(Guid pocketId);
    Task UpdatePocket(PocketModel pocketModel);
    Task DeletePocket(Guid pocketId);
}