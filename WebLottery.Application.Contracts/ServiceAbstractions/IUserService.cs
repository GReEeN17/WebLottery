using System.Security.Claims;
using WebLottery.Application.Contracts.ServiceAbstractionsResponses;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IUserService
{
    Task<RegisterResponse> Register(UserModel userModel);
    UserEntity? GetUser(string username);
    Task UpdateUser(UserEntity userEntity);
    Task<AuthenticatedResponse> LoginWithUsername(string username, string password);
    Task<AuthenticatedResponse> LoginWithEmail(string email, string password);
    ShowWalletResponse ShowWallet(IEnumerable<Claim> claims);
    Task<string> ShowJoinedDraws();
    Task<string> CreateDraw(int ticketPrice, int maxAmountPlayers);
    Task<CreateAdminResponse> CreateAdmin(IEnumerable<Claim> claims, UserModel adminModel);
    Task<UpgradeUserToAdminResponse> UpgradeUserToAdmin(IEnumerable<Claim> claims, Guid userId);
    Task<string> BuyTicket(Guid drawId);
    Task<string> CreateCurrency(string name, string abbreviation);
    Task<string> CreatePrize(string name, string? description, int? currencyId);
}