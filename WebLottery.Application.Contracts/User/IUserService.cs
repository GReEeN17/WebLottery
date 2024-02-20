using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Prize;

namespace WebLottery.Application.Contracts.User;

public interface IUserService
{
    UserLoginResult LoginWithUsername(string username, string password);
    UserLoginResult LoginWithEmail(string email, string password);
    UserUpdateResult UpdateUser(string? email, string? username, string? password);
    IEnumerable<Models.WalletCurrency.WalletCurrencyModel> ShowWallet();
    IEnumerable<DrawModel> ShowJoinedDraws();
    UserCreateGameResult CreateDraw(int ticketPrice, int maxAmountPlayers);
    UserCreateUserResult CreateUser(string username, string email, string password);
    UserBuyTicketResult BuyTicket(int drawId);
    UserCreateCurrencyResult CreateCurrency(string name, string abbreviation);
    UserCreatePrizeResult CreatePrize(string name, string? description, int? currencyId);
}