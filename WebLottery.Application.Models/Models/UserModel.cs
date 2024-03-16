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
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public WalletModel? Wallet { get; set; }
    public PocketModel? Pocket { get; set; }
}