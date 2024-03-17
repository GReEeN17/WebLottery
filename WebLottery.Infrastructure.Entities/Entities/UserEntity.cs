using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Infrastructure.Entities.Entities;

public class UserEntity : Entity
{
    public string UserName { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public WalletEntity Wallet { get; set; }
    public PocketEntity Pocket { get; set; }
}