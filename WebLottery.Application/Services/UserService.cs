using System.Security.Claims;
using System.Text.Json;
using AutoMapper;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Contracts.ServiceAbstractionsExtensions;
using WebLottery.Application.Models.Models;
using WebLottery.Application.ServiceExtensions;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;
using WebLottery.Infrastructure.Implementations.Jwt;

namespace WebLottery.Application.Services;

public class UserService(
    IDbRepository dbRepository,
    IMapper mapper,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider,
    IWalletService walletService,
    IPocketService pocketService)
    : IUserService
{
    public async Task<string> Register(UserModel userModel)
    {
        userModel.Password = passwordHasher.Generate(userModel.Password);
        var userEntity = mapper.Map<UserEntity>(userModel);
        
        var userEntityResult = await dbRepository.Add(userEntity);
        await dbRepository.SaveChangesAsync();

        var userWallet = new WalletModel()
        {
            UserId = userEntityResult.Id
        };

        await walletService.CreateWallet(userWallet);

        var userPocket = new PocketModel()
        {
            UserId = userEntityResult.Id
        };

        await pocketService.CreatePocket(userPocket);

        var result = new
        {
            Id = userEntityResult.Id,
            Username = userEntityResult.UserName,
            Password = userEntityResult.Password,
            Email = userEntityResult.EMail
        };

        return JsonSerializer.Serialize(result);
    }

    public UserEntity? GetUser(int userId)
    {
        return dbRepository.Get<UserEntity>().FirstOrDefault(x => x.Id == userId);
    }

    public async Task UpdateUser(UserEntity userEntity)
    { 
        await dbRepository.Update(userEntity);
        await dbRepository.SaveChangesAsync();
    }

    public async Task<AuthenticatedResponse?> LoginWithUsername(string username, string password)
    {
        var userEntity = dbRepository.Get<UserEntity>().FirstOrDefault(x => x.UserName == username);
        
        return await Login(userEntity, password);
    }

    public async Task<AuthenticatedResponse?> LoginWithEmail(string email, string password)
    {
        var userEntity = dbRepository.Get<UserEntity>().FirstOrDefault(x => x.EMail == email);

        return await Login(userEntity, password);
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

    private async Task<AuthenticatedResponse?> Login(UserEntity? userEntity, String password)
    {
        if (userEntity is null)
        {
            return null;
        }

        var result = passwordHasher.Verify(password, userEntity.Password);

        if (result is false)
        {
            return null;
        }
        
        Claim[] claims = [
            new Claim(ClaimTypes.Sid, userEntity.Id.ToString()),
            new Claim(ClaimTypes.Name, userEntity.UserName)
        ];
        
        var accessToken = jwtProvider.GenerateAccessToken(claims);
        var refreshToken = jwtProvider.GenerateRefreshToken();
        
        userEntity.RefreshToken = refreshToken;
        userEntity.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(jwtProvider.GetRefreshTokenExpiryDays());

        await dbRepository.Update(userEntity);
        await dbRepository.SaveChangesAsync();

        return new AuthenticatedResponse 
        {
            Token = accessToken,
            RefreshToken = refreshToken
        };
    }
}