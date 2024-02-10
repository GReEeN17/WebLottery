using Models.Pockets;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IPocketRepository
{
    Pocket? GetUserPocket(Guid userId);
}