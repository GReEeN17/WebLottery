using Models.Abstractions;
using Models.Draws;
using Models.Users;

namespace Models.UserDraw;

public class UserDraw : Entity
{
    public User User { get; set; }
    public Draw Draw { get; set; }
}