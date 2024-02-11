using Models.Currencies;
using Models.Draws;
using Models.Users;
using WebLottery.Application.Abstractions.Repositories;
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
    
    public UserService(
        IUserRepository userRepository,
        IWalletService walletService,
        IPocketService pocketService,
        CurrentUserManager currentUserManager,
        IUserDrawService userDrawService)
    {
        _userRepository = userRepository;
        _walletService = walletService;
        _pocketService = pocketService;
        _currentUserManager = currentUserManager;
        _userDrawService = userDrawService;
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

        return _walletService.GetUserWalletCurrency(_currentUserManager.User.Id);
    }

    public IEnumerable<Draw> ShowJoinedDraws()
    {
        if (_currentUserManager.User is null)
        {
            return new List<Draw>();
        }

        return _userDrawService.GetUserDraws(_currentUserManager.User.Id);
    }

    public UserCreateGameResult CreateGame()
    {
        throw new NotImplementedException();
    }

    public UserCreateUserResult CreateUser(string username, string email, string password)
    {
        throw new NotImplementedException();
    }

    public UserBuyTicketResult BuyTicket(int amount)
    {
        throw new NotImplementedException();
    }
}