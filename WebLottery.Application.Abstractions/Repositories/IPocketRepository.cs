using Models.Pockets;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IPocketRepository
{
    Pocket CreatePocket();
    Pocket? GetUserPocket(Guid userId);
}