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
    public int WalletId { get; set; }
    public WalletEntity Wallet { get; set; }
    public int PocketId { get; set; }
    public PocketEntity Pocket { get; set; }
}