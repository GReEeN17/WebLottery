using Models.Users;
using WebLottery.Application.Contracts.Users;

namespace WebLottery.Application.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}