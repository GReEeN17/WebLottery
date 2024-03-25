using System.Net;
using System.Security.Claims;
using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLottery.Application.Contracts.DbResponses;
using WebLottery.Application.Contracts.Requests;
using WebLottery.Application.Contracts.Responses;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Contracts.ServiceAbstractionsModels;
using WebLottery.Application.Defaults;
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
    IPocketService pocketService,
    IDrawService drawService)
    : IUserService
{
    public async Task<RegisterResponse> Register(UserModel userModel)
    {
        var registerResponse = new RegisterResponse();
        
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

        var registerDbResponse = new RegisterDbResponse
        {
            Username = userEntityResult.UserName,
            UserRole = userEntityResult.UserRole
        };
        
        registerResponse.Status = HttpStatusCode.OK;
        registerResponse.Comments = "Ok";
        registerResponse.Value = registerDbResponse;
        
        return registerResponse;
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

    public async Task<AuthenticatedResponse> LoginWithUsername(UserUsernameLoginRequest userUsernameLoginRequest)
    {
        var userEntity = dbRepository.Get<UserEntity>().FirstOrDefault(x => x.UserName == userUsernameLoginRequest.Username);
        
        return await Login(userEntity, userUsernameLoginRequest.Password);
    }

    public async Task<AuthenticatedResponse> LoginWithEmail(UserEmailLoginRequest userEmailLoginRequest)
    {
        var userEntity = dbRepository.Get<UserEntity>().FirstOrDefault(x => x.EMail == userEmailLoginRequest.Email);

        return await Login(userEntity, userEmailLoginRequest.Password);
    }

    public ShowWalletResponse ShowWallet(IEnumerable<Claim> claims)
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
            showWalletResponse.Status = HttpStatusCode.BadRequest;
            showWalletResponse.Comments = "Invalid user request";
            showWalletResponse.Value = null;
            return showWalletResponse;
        }
        
        var userWalletCurrencies = userEntity.Wallet.WalletCurrencies;

        var showWalletDbResponse = new ShowWalletDbResponse
        {
            Wallet = new List<ShowWallet>()
        };

        foreach (var userWalletCurrency in userWalletCurrencies)
        {
            showWalletDbResponse.Wallet.Add(new ShowWallet
            {
                CurrencyName = userWalletCurrency.Currency.Name,
                Amount = userWalletCurrency.Amount
            });
        }

        showWalletResponse.Status = HttpStatusCode.OK;
        showWalletResponse.Comments = "Ok";
        showWalletResponse.Value = showWalletDbResponse;
        
        return showWalletResponse;
    }

    public ShowJoinedGamesResponse ShowJoinedDraws(IEnumerable<Claim> claims)
    {
        var showJoinedGamesResponse = new ShowJoinedGamesResponse();

        var userUsername = claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();

        if (userUsername is null)
        {
            showJoinedGamesResponse.Status = HttpStatusCode.BadRequest;
            showJoinedGamesResponse.Comments = "Invalid client request";
            showJoinedGamesResponse.Value = null;
            return showJoinedGamesResponse;
        }

        var userEntity = dbRepository.Get<UserEntity>()
            .Include(user => user.Pocket)
            .ThenInclude(pocket => pocket.PocketTickets)
            .ThenInclude(ticketList => ticketList.Ticket)
            .ThenInclude(ticket => ticket.Draw)
            .FirstOrDefault(user => user.UserName == userUsername);

        if (userEntity is null)
        {
            showJoinedGamesResponse.Status = HttpStatusCode.BadRequest;
            showJoinedGamesResponse.Comments = "Invalid client request";
            showJoinedGamesResponse.Value = null;
            return showJoinedGamesResponse;
        }

        return showJoinedGamesResponse;
    }

    public async Task<CreateDrawResponse> CreateDraw(IEnumerable<Claim> claims, DrawModel drawModel)
    {
        var createDrawResponse = new CreateDrawResponse();

        var enumerable = claims.ToList();
        var userRequestRole = enumerable.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();
        var userRequestUsername = enumerable.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
        
        if (userRequestUsername is null || userRequestRole is null)
        {
            createDrawResponse.Status = HttpStatusCode.BadRequest;
            createDrawResponse.Comments = "Invalid client request";
            createDrawResponse.Value = null;
            return createDrawResponse;
        }
        
        var userRequest = dbRepository.Get<UserEntity>()
            .Include(user => user.Wallet)
            .ThenInclude(wallet => wallet.WalletCurrencies)
            .ThenInclude(walletCurrency => walletCurrency.Currency)
            .FirstOrDefault(user => user.UserName == userRequestUsername);

        if (userRequest is null)
        {
            createDrawResponse.Status = HttpStatusCode.BadRequest;
            createDrawResponse.Comments = "Invalid client request";
            createDrawResponse.Value = null;
            return createDrawResponse;
        }
        
        var tokenCurrencyAmount = userRequest.Wallet.WalletCurrencies
            .FirstOrDefault(walletCurrency => walletCurrency.Currency.Id == ServiceDefaults.MakingDrawCurrency.GetServiceDefaultCurrencyGuid())?.Amount;
        
        if (userRequestRole == UserRole.Player.GetUserRole() && tokenCurrencyAmount < ServiceDefaults.MinimumAmountToJoinDraw.GetServiceDefaultMinimumAmountToJoinDraw())
        {
            createDrawResponse.Status = HttpStatusCode.Forbidden;
            createDrawResponse.Comments = "Forbidden to create draw, you have not enough tokens";
            createDrawResponse.Value = null;
            return createDrawResponse;
        }
        
        if (userRequestRole != UserRole.Admin.GetUserRole())
        {
            userRequest.Wallet.WalletCurrencies
                .FirstOrDefault(walletCurrency => walletCurrency.Currency.Id ==
                                                  ServiceDefaults.MakingDrawCurrency.GetServiceDefaultCurrencyGuid())!
                .Amount -= ServiceDefaults.MinimumAmountToJoinDraw.GetServiceDefaultMinimumAmountToJoinDraw(); 
        }

        var drawEntity = await drawService.CreateDraw(drawModel);
        
        createDrawResponse.Status = HttpStatusCode.OK;
        createDrawResponse.Comments = "Ok";
        createDrawResponse.Value = new CreateDrawDbResponse
        {
            DrawId = drawEntity.Id,
            TicketPrice = drawEntity.TicketPrice,
            MaxAmountPlayers = drawEntity.MaxAmountPlayers
        };

        return createDrawResponse;
    }

    public async Task<CreateAdminResponse> CreateAdmin(IEnumerable<Claim> claims, UserModel adminModel)
    {
        var createAdminResponse = new CreateAdminResponse();

        var userRequestRole = claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();

        if (userRequestRole != UserRole.Admin.GetUserRole())
        {
            createAdminResponse.Status = HttpStatusCode.Forbidden;
            createAdminResponse.Comments = "Forbidden to create admin, you are not admin";
            createAdminResponse.Value = null;
            return createAdminResponse;
        }

        adminModel.Password = passwordHasher.Generate(adminModel.Password);
        adminModel.UserRole = UserRole.Admin;

        var adminEntity = mapper.Map<UserEntity>(adminModel);

        await dbRepository.Add(adminEntity);
        await dbRepository.SaveChangesAsync();

        var createAdminDbResponse = new CreateAdminDbResponse
        {
            Username = adminEntity.UserName,
            UserRole = adminEntity.UserRole
        };

        createAdminResponse.Status = HttpStatusCode.OK;
        createAdminResponse.Comments = "Ok";
        createAdminResponse.Value = createAdminDbResponse;

        return createAdminResponse;
    }

    public async Task<UpgradeUserToAdminResponse> UpgradeUserToAdmin(IEnumerable<Claim> claims, Guid userId)
    {
        var upgradeUserToAdminResponse = new UpgradeUserToAdminResponse();

        var userRequestRole = claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();

        if (userRequestRole != UserRole.Admin.GetUserRole())
        {
            upgradeUserToAdminResponse.Status = HttpStatusCode.Forbidden;
            upgradeUserToAdminResponse.Comments = "Forbidden to upgrade user, you are not admin";
            upgradeUserToAdminResponse.Value = null;
            return upgradeUserToAdminResponse;
        }
        
        var userEntity = dbRepository.Get<UserEntity>().FirstOrDefault(user => user.Id == userId);

        if (userEntity is null)
        {
            upgradeUserToAdminResponse.Status = HttpStatusCode.BadRequest;
            upgradeUserToAdminResponse.Comments = "Invalid client request";
            upgradeUserToAdminResponse.Value = null;
            return upgradeUserToAdminResponse;
        }

        userEntity.UserRole = UserRole.Admin;

        await dbRepository.Update(userEntity);
        await dbRepository.SaveChangesAsync();

        var upgradeUserToAdminDbResponse = new UpgradeUserToAdminDbResponse
        {
            Username = userEntity.UserName,
            UserRole = userEntity.UserRole
        };

        upgradeUserToAdminResponse.Status = HttpStatusCode.OK;
        upgradeUserToAdminResponse.Comments = "Ok";
        upgradeUserToAdminResponse.Value = upgradeUserToAdminDbResponse;
        return upgradeUserToAdminResponse;
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

    private async Task<AuthenticatedResponse> Login(UserEntity? userEntity, String password)
    {
        var authenticatedResponse = new AuthenticatedResponse();
        
        if (userEntity is null)
        {
            authenticatedResponse.Status = HttpStatusCode.BadRequest;
            authenticatedResponse.Comments = "Invalid user request";
            authenticatedResponse.Value = null;
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

        var authenticatedDbResponse = new AuthenticatedDbResponse
        {
            Token = accessToken,
            RefreshToken = refreshToken
        };

        authenticatedResponse.Status = HttpStatusCode.OK;
        authenticatedResponse.Comments = "Ok";
        authenticatedResponse.Value = authenticatedDbResponse;
        
        return authenticatedResponse;
    }
}