using System.Text.Json;
using AutoMapper;
using WebLottery.Application.Contracts.Pocket;
using WebLottery.Application.Contracts.User;
using WebLottery.Application.Contracts.Wallet;
using WebLottery.Application.Models.Pocket;
using WebLottery.Application.Models.User;
using WebLottery.Application.Models.Wallet;
using WebLottery.Application.Responses;
using WebLottery.Infrastructure.Entities.User;
using WebLottery.Infrastructure.Implementations.Abstractions;
using WebLottery.Infrastructure.Implementations.Jwt;

namespace WebLottery.Application.User;

public class UserService : IUserService
{
    private readonly IDbRepository _dbRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    private readonly IWalletService _walletService;
    private readonly IPocketService _pocketService;

    public UserService(
        IDbRepository dbRepository,
        IMapper mapper, 
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider,
        IWalletService walletService,
        IPocketService pocketService
        )
    {
        _dbRepository = dbRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
        _walletService = walletService;
        _pocketService = pocketService;
    }
    
    public async Task<string> Register(UserModel userModel)
    {
        userModel.Password = _passwordHasher.Generate(userModel.Password);
        var userEntity = _mapper.Map<UserEntity>(userModel);
        
        var userEntityResult = await _dbRepository.Add(userEntity);
        await _dbRepository.SaveChangesAsync();

        var userWallet = new WalletModel()
        {
            UserId = userEntityResult.Id
        };

        await _walletService.CreateWallet(userWallet);

        var userPocket = new PocketModel()
        {
            UserId = userEntityResult.Id
        };

        await _pocketService.CreatePocket(userPocket);

        var result = new
        {
            Id = userEntityResult.Id,
            Username = userEntityResult.UserName,
            Password = userEntityResult.Password,
            Email = userEntityResult.EMail
        };

        return JsonSerializer.Serialize(result);
    }

    public string LoginWithUsername(string username, string password)
    {
        var userEntity = _dbRepository.Get<UserEntity>().FirstOrDefault(x => x.UserName == username);

        if (userEntity is null)
        {
            return JsonSerializer.Serialize("Error, user was not found");
        }

        var result = _passwordHasher.Verify(password, userEntity.Password);

        if (result is false)
        {
            return JsonSerializer.Serialize("Error, password or email is invalid");
        }

        var token = _jwtProvider.GenerateAccessToken(userEntity);

        return JsonSerializer.Serialize(token);
    }

    public async Task<AuthenticatedResponse?> LoginWithEmail(string email, string password)
    {
        var userEntity = _dbRepository.Get<UserEntity>().FirstOrDefault(x => x.EMail == email);

        if (userEntity is null)
        {
            return null;
        }

        var result = _passwordHasher.Verify(password, userEntity.Password);

        if (result is false)
        {
            return null;
        }

        var accessToken = _jwtProvider.GenerateAccessToken(userEntity);
        var refreshToken = _jwtProvider.GenerateRefreshToken();
        
        userEntity.RefreshToken = refreshToken;
        userEntity.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtProvider.GetRefreshTokenExpiryDays());

        await _dbRepository.Update(userEntity);
        await _dbRepository.SaveChangesAsync();

        AuthenticatedResponse authenticatedResponse = new AuthenticatedResponse
        {
            Token = accessToken,
            RefreshToken = refreshToken
        };

        return authenticatedResponse;
    }

    public Task<string> UpdateUser(string? email, string? username, string? password)
    {
        throw new NotImplementedException();
    }

    public Task<string> ShowWallet()
    {
        throw new NotImplementedException();
    }

    public Task<string> ShowJoinedDraws()
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateDraw(int ticketPrice, int maxAmountPlayers)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateUser(string username, string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<string> BuyTicket(int drawId)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateCurrency(string name, string abbreviation)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreatePrize(string name, string? description, int? currencyId)
    {
        throw new NotImplementedException();
    }
}