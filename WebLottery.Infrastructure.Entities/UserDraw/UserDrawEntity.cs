using Models.Abstractions;
using Models.Draw;
using Models.User;

namespace Models.UserDraw;

public class UserDrawEntity : Entity
{
    public UserEntity UserEntity { get; set; }
    public DrawEntity DrawEntity { get; set; }
}