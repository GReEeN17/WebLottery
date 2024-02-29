using WebLottery.Application.Contracts.Currency;
using WebLottery.Application.Contracts.Draw;
using WebLottery.Application.Contracts.Pocket;
using WebLottery.Application.Contracts.Prize;
using WebLottery.Application.Contracts.User;
using WebLottery.Application.Contracts.Wallet;
using WebLottery.Application.Models.User;
using WebLottery.Infrastructure.Entities.User;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.User;

public class UserService : IUserService
{
    private readonly IDbRepository _userRepository;
    private readonly IWalletService _walletService;
    private readonly IPocketService _pocketService;
    private readonly CurrentUserManager _currentUserManager;
    private readonly IDrawService _drawService;
    private readonly ICurrencyService _currencyService;
    private readonly IPrizeService _prizeService;
    
    public UserService(
        IDbRepository userRepository,
        IWalletService walletService,
        IPocketService pocketService,
        CurrentUserManager currentUserManager,
        IDrawService drawService,
        ICurrencyService currencyService,
        IPrizeService prizeService)
    {
        _userRepository = userRepository;
        _walletService = walletService;
        _pocketService = pocketService;
        _currentUserManager = currentUserManager;
        _drawService = drawService;
        _currencyService = currencyService;
        _prizeService = prizeService;
    }


    public UserLoginResult LoginWithUsername(string username, string password)
    {
        UserModel? user = _userRepository;

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
        UserModel? user = _userRepository.FindUserByEmail(email).Result;

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

    public UserUpdateResult UpdateUser(string? email, string? username, string? password)
    {
        if (_currentUserManager.User is null)
        {
            return new UserUpdateResult.NotAuthorized();
        }

        _userRepository.UpdateUser(_currentUserManager.User.Id, email, username, password);
        return new UserUpdateResult.Success();
    }

    public IEnumerable<Models.WalletCurrency.WalletCurrencyModel> ShowWallet()
    {
        if (_currentUserManager.User is null)
        {
            return new List<Models.WalletCurrency.WalletCurrencyModel>();
        }

        return _walletService.GetAllUserCurrencies(_currentUserManager.User.Id);
    }

    public IEnumerable<Models.Draw.DrawModel> ShowJoinedDraws()
    {
        if (_currentUserManager.User is null)
        {
            return new List<Models.Draw.DrawModel>();
        }

        return _pocketService.GetAllUserDraws(_currentUserManager.User.Id);
    }

    public UserCreateGameResult CreateDraw(int ticketPrice, int maxAmountPlayers)
    {
        if (_currentUserManager.User is null)
        {
            return new UserCreateGameResult.NotAuthorized();
        }

        Models.WalletCurrency.WalletCurrencyModel walletToken =
            _walletService.GetUserCurrency(_currentUserManager.User.Id, CurrencyIndex.Tokens.GetCurrencyIndex());

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

        UserModel newUser = _userRepository.CreateUser(username, email, password).Result;
        _walletService.CreateWallet(newUser.Id);
        _pocketService.CreatePocket(newUser.Id);
        return new UserCreateUserResult.Success();
    }

    public UserBuyTicketResult BuyTicket(int drawId)
    {
        if (_currentUserManager.User is null)
        {
            return new UserBuyTicketResult.NotAuthorized();
        }

        int ticketPrice = _drawService.GetDraw(drawId).TicketPrice;

        Models.WalletCurrency.WalletCurrencyModel walletCoin =
            _walletService.GetUserCurrency(_currentUserManager.User.Id, CurrencyIndex.Coins.GetCurrencyIndex());

        if (walletCoin.Amount < ticketPrice)
        {
            return new UserBuyTicketResult.NotEnoughMoney();
        }

        _userRepository.UserBudgetWithdraw(_currentUserManager.User.Id, walletCoin.Id, ticketPrice);
        _pocketService.BuyTicket(_currentUserManager.User.Id, drawId);
        return new UserBuyTicketResult.Success();
    }

    public UserCreateCurrencyResult CreateCurrency(string name, string abbreviation)
    {
        if (_currentUserManager.User is null)
        {
            return new UserCreateCurrencyResult.NotAuthorized();
        }

        if (_currentUserManager.User.UserRole is not UserRole.Admin)
        {
            return new UserCreateCurrencyResult.NotEnoughRights();
        }
        
        _currencyService.CreateCurrency(name, abbreviation);
        return new UserCreateCurrencyResult.Success();
    }

    public UserCreatePrizeResult CreatePrize(string name, string? description, int? currencyId)
    {
        if (_currentUserManager.User is null)
        {
            return new UserCreatePrizeResult.NotAuthorized();
        }

        if (_currentUserManager.User.UserRole is not UserRole.Admin)
        {
            return new UserCreatePrizeResult.NotEnoughRights();
        }
        
        _prizeService.CreatePrize(name, description, currencyId);
        return new UserCreatePrizeResult.Success();
    }
}