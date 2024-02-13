using WebLottery.Application.Models.User;

namespace WebLottery.Application.Contracts.User;

public interface ICurrentUserService
{
    UserModel? User { get; }
}