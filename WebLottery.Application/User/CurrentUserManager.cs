using Models.User;
using WebLottery.Application.Contracts.Users;
using WebLottery.Application.Models.User;

namespace WebLottery.Application.Users;

public class CurrentUserManager : ICurrentUserService
{
    public UserModel? User { get; set; }
}