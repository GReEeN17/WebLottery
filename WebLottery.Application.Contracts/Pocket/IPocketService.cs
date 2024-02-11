using Models.Pockets;

namespace WebLottery.Application.Contracts.Pockets;

public interface IPocketService
{
    void CreatePocket();
    Pocket GetUserPocket(int userId);
}