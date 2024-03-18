using System.Security.Claims;
using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Contracts.ServiceAbstractionsResponses;
using WebLottery.Application.Models.Models;
using WebLottery.Application.ServiceExtensions;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Entities.EntitiesExtensions;
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
        userModel.UserRole = UserRole.Player;
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

    public UserEntity? GetUser(string username)
    {
        return dbRepository.Get<UserEntity>().FirstOrDefault(x => x.UserName == username);
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

    public ShowWalletResponse? ShowWallet(IEnumerable<Claim> claims)
    {
        var username = claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();
        
        var userEntity = dbRepository.Get<UserEntity>()
            .Include(user => user.Wallet)
            .ThenInclude(wallet => wallet.WalletCurrencies)
            .ThenInclude(walletCurrency => walletCurrency.Currency)
            .FirstOrDefault(x => x.UserName == username);
        
        var showWalletResponse = new ShowWalletResponse();

        if (userEntity is null)
        {
            showWalletResponse.Status = 400;
            showWalletResponse.Comments = "Invalid user request";
            showWalletResponse.Wallet = null;
            return showWalletResponse;
        }
        
        var userWalletCurrencies = userEntity.Wallet.WalletCurrencies;

        foreach (var userWalletCurrency in userWalletCurrencies)
        {
            showWalletResponse.Wallet!.Add(new ShowWallet
            {
                CurrencyName = userWalletCurrency.Currency.Name,
                Amount = userWalletCurrency.Amount
            });
        }

        showWalletResponse.Status = 200;
        showWalletResponse.Comments = "Ok";
        
        return showWalletResponse;
    }

    public Task<string> ShowJoinedDraws()
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateDraw(int ticketPrice, int maxAmountPlayers)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateAdmin(string username, string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task UpgradeUserToAdmin(Guid userId)
    {
        
    }

    public Task<string> BuyTicket(Guid drawId)
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
        var authenticatedResponse = new AuthenticatedResponse();
        
        if (userEntity is null)
        {
            authenticatedResponse.Status = 400;
            authenticatedResponse.Comments = "Invalid user request";
            authenticatedResponse.RefreshToken = null;
            authenticatedResponse.Token = null;
            return authenticatedResponse;
        }

        var result = passwordHasher.Verify(password, userEntity.Password);

        if (result is false)
        {
            return null;
        }
        
        Claim[] claims = [
            new Claim(ClaimTypes.Name, userEntity.UserName),
            new Claim(ClaimTypes.Role, userEntity.UserRole.GetUserRole())
        ];
        
        var accessToken = jwtProvider.GenerateAccessToken(claims);
        var refreshToken = jwtProvider.GenerateRefreshToken();
        
        userEntity.RefreshToken = refreshToken;
        userEntity.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(jwtProvider.GetRefreshTokenExpiryDays());

        await dbRepository.Update(userEntity);
        await dbRepository.SaveChangesAsync();

        authenticatedResponse.Status = 200;
        authenticatedResponse.Comments = "Ok";
        authenticatedResponse.Token = accessToken;
        authenticatedResponse.RefreshToken = refreshToken;
        
        return authenticatedResponse;
    }
}