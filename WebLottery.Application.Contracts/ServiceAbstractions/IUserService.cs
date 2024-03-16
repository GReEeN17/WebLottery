using WebLottery.Application.Contracts.ServiceAbstractionsExtensions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IUserService
{
    Task<string> Register(UserModel userModel);
    UserEntity? GetUser(int userId);
    Task UpdateUser(UserEntity userEntity);
    Task<AuthenticatedResponse?> LoginWithUsername(string username, string password);
    Task<AuthenticatedResponse?> LoginWithEmail(string email, string password);
    Task<string> ShowWallet();
    Task<string> ShowJoinedDraws();
    Task<string> CreateDraw(int ticketPrice, int maxAmountPlayers);
    Task<string> CreateUser(string username, string email, string password);
    Task<string> BuyTicket(int drawId);
    Task<string> CreateCurrency(string name, string abbreviation);
    Task<string> CreatePrize(string name, string? description, int? currencyId);
}