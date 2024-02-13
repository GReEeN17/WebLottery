using WebLottery.Application.Contracts.User;
using WebLottery.Application.Models.User;

namespace WebLottery.Application.User;

public class CurrentUserManager : ICurrentUserService
{
    public UserModel? User { get; set; }
}