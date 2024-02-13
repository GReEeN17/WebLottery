using Models.Draw;
using Models.Prize;
using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Prize;

namespace WebLottery.Application.Contracts.Users;

public interface IUserService
{
    UserLoginResult LoginWithUsername(string username, string password);
    UserLoginResult LoginWithEmail(string email, string password);
    IEnumerable<Models.WalletCurrency.WalletCurrencyModel> ShowWallet();
    IEnumerable<DrawModel> ShowJoinedDraws();
    UserCreateGameResult CreateGame(int ticketPrice, int maxAmountPlayers);
    UserCreateUserResult CreateUser(string username, string email, string password);
    UserBuyTicketResult BuyTicket(int drawId, int amount, int luckyNumber);
    UserCreateCurrencyResult CreateCurrency(string name, string abbreviation);
    UserCreatePrizeResult CreatePrize(string name, string? description, int? currencyId);
    IEnumerable<PrizeModel> ShowClaimedPrizes();
}