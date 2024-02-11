using Models.Users;

namespace WebLottery.Application.Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
}