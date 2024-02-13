using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.User;

namespace WebLottery.Application.Models.UserDraw;

public class UserDrawModel
{
    public int Id { get; set; }
    public UserModel User { get; set; }
    public DrawModel Draw { get; set; }
}