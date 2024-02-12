using Models.Users;
using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Draws;
using WebLottery.Application.Contracts.Pockets;
using WebLottery.Application.Contracts.UserDraw;
using WebLottery.Application.Contracts.Users;
using WebLottery.Application.Contracts.Wallets;

namespace WebLottery.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IWalletService _walletService;
    private readonly IPocketService _pocketService;
    private readonly CurrentUserManager _currentUserManager;
    private readonly IUserDrawService _userDrawService;
    private readonly IDrawService _drawService;
    
    public UserService(
        IUserRepository userRepository,
        IWalletService walletService,
        IPocketService pocketService,
        CurrentUserManager currentUserManager,
        IUserDrawService userDrawService,
        IDrawService drawService)
    {
        _userRepository = userRepository;
        _walletService = walletService;
        _pocketService = pocketService;
        _currentUserManager = currentUserManager;
        _userDrawService = userDrawService;
        _drawService = drawService;
    }


    public UserLoginResult LoginWithUsername(string username, string password)
    {
        User? user = _userRepository.FindUserByUsername(username).Result;

        if (user is null)
        {
            return new UserLoginResult.UserNotFound();
        }
        else if (user.Password != password)
        {
            return new UserLoginResult.IncorrectPassword();
        }

        _currentUserManager.User = user;
        return new UserLoginResult.Success();
    }

    public UserLoginResult LoginWithEmail(string email, string password)
    {
        User? user = _userRepository.FindUserByEmail(email).Result;

        if (user is null)
        {
            return new UserLoginResult.UserNotFound();
        }
        else if (user.Password != password)
        {
            return new UserLoginResult.IncorrectPassword();
        }

        _currentUserManager.User = user;
        return new UserLoginResult.Success();
    }

    public IEnumerable<Models.WalletCurrency.WalletCurrency> ShowWallet()
    {
        if (_currentUserManager.User is null)
        {
            return new List<Models.WalletCurrency.WalletCurrency>();
        }

        return _walletService.GetAllUserWalletCurrency(_currentUserManager.User.Id);
    }

    public IEnumerable<Models.Draws.Draw> ShowJoinedDraws()
    {
        if (_currentUserManager.User is null)
        {
            return new List<Models.Draws.Draw>();
        }

        return _userDrawService.GetUserDraws(_currentUserManager.User.Id);
    }

    public UserCreateGameResult CreateGame(int ticketPrice, int maxAmountPlayers)
    {
        if (_currentUserManager.User is null)
        {
            return new UserCreateGameResult.NotAuthorized();
        }

        Models.WalletCurrency.WalletCurrency walletToken =
            _walletService.GetUserWalletCurrency(_currentUserManager.User.Id, CurrencyIndex.Tokens.GetCurrencyIndex());

        if (_currentUserManager.User.UserRole is UserRole.Player && walletToken.Amount < 1)
        {
            return new UserCreateGameResult.NotEnoughMoney();
        }
        
        _drawService.CreateDraw(ticketPrice, maxAmountPlayers);
        return new UserCreateGameResult.Success();
    }

    public UserCreateUserResult CreateUser(string username, string email, string password)
    {
        if (_currentUserManager.User is null)
        {
            return new UserCreateUserResult.NotAuthorized();
        }

        if (_currentUserManager.User.UserRole is not UserRole.Admin)
        {
            return new UserCreateUserResult.NotEnoughRights();
        }

        User newUser = _userRepository.CreateUser(username, email, password).Result;
        _walletService.CreateWallet(newUser.Id);
        _pocketService.CreatePocket(newUser.Id);
        return new UserCreateUserResult.Success();
    }

    public UserBuyTicketResult BuyTicket(int drawId, int amount, int luckyNumber)
    {
        if (_currentUserManager.User is null)
        {
            return new UserBuyTicketResult.NotAuthorized();
        }

        Models.WalletCurrency.WalletCurrency walletCoin =
            _walletService.GetUserWalletCurrency(_currentUserManager.User.Id, CurrencyIndex.Coins.GetCurrencyIndex());

        if (walletCoin.Amount < amount)
        {
            return new UserBuyTicketResult.NotEnoughMoney();
        }

        _userRepository.UserBudgetWithdraw(_currentUserManager.User.Id, walletCoin.Id, amount);
        _pocketService.BuyTicket(_currentUserManager.User.Id, luckyNumber, drawId);
        _userDrawService.CreateUserDraw(_currentUserManager.User.Id, drawId);
        return new UserBuyTicketResult.Success();
    }
}