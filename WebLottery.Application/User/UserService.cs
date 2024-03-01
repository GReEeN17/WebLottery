using WebLottery.Application.Contracts.User;

namespace WebLottery.Application.User;

public class UserService : IUserService
{
    public Task<string> LoginWithUsername(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<string> LoginWithEmail(string email, string password)
    {
        throw new NotImplementedException();
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