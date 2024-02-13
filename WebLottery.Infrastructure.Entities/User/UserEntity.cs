using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.Pocket;
using WebLottery.Infrastructure.Entities.Wallet;

namespace WebLottery.Infrastructure.Entities.User;

public class UserEntity : Entity
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
    public List<UserDraw.UserDrawEntity> UserDraws { get; set; }
}