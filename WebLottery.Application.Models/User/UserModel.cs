using WebLottery.Application.Models.Pocket;
using WebLottery.Application.Models.Wallet;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Application.Models.User;

public class UserModel
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
    public List<UserDraw.UserDrawModel> UserDraws { get; set; }
}