using Models.User;
using WebLottery.Application.Models.User;

namespace WebLottery.Application.Contracts.Users;

public interface ICurrentUserService
{
    UserModel? User { get; }
}