using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.Draw;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Infrastructure.Entities.UserDraw;

public class UserDrawEntity : Entity
{
    public int Id { get; set; }
    public UserEntity User { get; set; }
    public DrawEntity Draw { get; set; }
}