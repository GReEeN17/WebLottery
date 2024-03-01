using WebLottery.Application.Contracts.Pocket;
using WebLottery.Application.Models.Pocket;

namespace WebLottery.Application.Pocket;

public class PocketService : IPocketService
{
    public Task<string> CreatePocket(PocketModel pocketModel)
    {
        throw new NotImplementedException();
    }

    public string GetPocket(int pocketId)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePocket(PocketModel pocketModel)
    {
        throw new NotImplementedException();
    }

    public Task DeletePocket(int pocketId)
    {
        throw new NotImplementedException();
    }
}