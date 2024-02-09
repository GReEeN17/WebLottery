using Models.Abstractions;

namespace Models.Users;

public class User : Entity
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string EMail { get; set; }
    public string password { get; set; }
    public Wallet Wallet { get; set; }
}