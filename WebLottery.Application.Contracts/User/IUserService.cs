using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Prize;

namespace WebLottery.Application.Contracts.User;

public interface IUserService
{
    Task<string> LoginWithUsername(string username, string password);
    Task<string> LoginWithEmail(string email, string password);
    Task<string> UpdateUser(string? email, string? username, string? password);
    Task<string> ShowWallet();
    Task<string> ShowJoinedDraws();
    Task<string> CreateDraw(int ticketPrice, int maxAmountPlayers);
    Task<string> CreateUser(string username, string email, string password);
    Task<string> BuyTicket(int drawId);
    Task<string> CreateCurrency(string name, string abbreviation);
    Task<string> CreatePrize(string name, string? description, int? currencyId);
}