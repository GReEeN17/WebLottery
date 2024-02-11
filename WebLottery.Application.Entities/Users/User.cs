using Models.Abstractions;
using Models.Pockets;

namespace Models.Users;

public class User : Entity
{
    public string UserName { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
    public Wallet Wallet { get; set; }
    public Pocket Pocket { get; set; }
    public List<UserDraw.UserDraw> UserDraws { get; set; }
}