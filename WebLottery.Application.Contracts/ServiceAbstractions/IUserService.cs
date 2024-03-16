using WebLottery.Application.Models.User;
using WebLottery.Application.Responses;
using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Application.Contracts.User;

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