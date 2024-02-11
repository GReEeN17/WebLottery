using Models.Currencies;
using Models.Draws;

namespace WebLottery.Application.Contracts.Users;

public interface IUserService
{
    UserLoginResult LoginWithUsername(string username, string password);
    UserLoginResult LoginWithEmail(string email, string password);
    IEnumerable<Models.WalletCurrency.WalletCurrency> ShowWallet();
    IEnumerable<Draw> ShowJoinedDraws();
    UserCreateGameResult CreateGame();
    UserCreateUserResult CreateUser(string username, string email, string password);
    UserBuyTicketResult BuyTicket(int amount);
}