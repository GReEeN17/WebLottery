using System.Security.Claims;
using WebLottery.Application.Contracts.Requests;
using WebLottery.Application.Contracts.Responses;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IUserService
{
    Task<RegisterResponse> Register(UserModel userModel);
    UserEntity? GetUser(string username);
    Task UpdateUser(UserEntity userEntity);
    Task<AuthenticatedResponse> LoginWithUsername(UserUsernameLoginRequest userUsernameLoginRequest);
    Task<AuthenticatedResponse> LoginWithEmail(UserEmailLoginRequest userEmailLoginRequest);
    ShowWalletResponse ShowWallet(IEnumerable<Claim> claims);
    ShowJoinedGamesResponse ShowJoinedDraws(IEnumerable<Claim> claims);
    Task<CreateDrawResponse> CreateDraw(IEnumerable<Claim> claims, DrawModel drawModel);
    Task<CreateAdminResponse> CreateAdmin(IEnumerable<Claim> claims, UserModel adminModel);
    Task<UpgradeUserToAdminResponse> UpgradeUserToAdmin(IEnumerable<Claim> claims, Guid userId);
    Task<BuyTicketResponse> BuyTicket(IEnumerable<Claim> claims, Guid drawId);
}