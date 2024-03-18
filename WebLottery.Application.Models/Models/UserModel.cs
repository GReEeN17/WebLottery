using WebLottery.Infrastructure.Entities.EntitiesExtensions;

namespace WebLottery.Application.Models.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public WalletModel? Wallet { get; set; }
    public PocketModel? Pocket { get; set; }
}