using Models.Currencies;
using Models.Draws;
using Models.Prizes;

namespace WebLottery.Application.Contracts.Users;

public interface IUserService
{
    UserLoginResult LoginWithUsername(string username, string password);
    UserLoginResult LoginWithEmail(string email, string password);
    IEnumerable<Models.WalletCurrency.WalletCurrency> ShowWallet();
    IEnumerable<Draw> ShowJoinedDraws();
    UserCreateGameResult CreateGame(int ticketPrice, int maxAmountPlayers);
    UserCreateUserResult CreateUser(string username, string email, string password);
    UserBuyTicketResult BuyTicket(int drawId, int amount, int luckyNumber);
    UserCreateCurrencyResult CreateCurrency(string name, string abbreviation);
    UserCreatePrizeResult CreatePrize(string name, string? description, int? currencyId);
    IEnumerable<Prize> ShowClaimedPrizes();
}