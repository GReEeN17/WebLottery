using Models.Abstractions;
using Models.Pocket;

namespace Models.User;

public class UserEntity : Entity
{
    public string UserName { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
    public WalletEntity WalletEntity { get; set; }
    public PocketEntity PocketEntity { get; set; }
    public List<UserDraw.UserDrawEntity> UserDraws { get; set; }
}