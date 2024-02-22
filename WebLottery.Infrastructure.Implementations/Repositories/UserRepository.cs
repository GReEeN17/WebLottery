using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Models.User;

namespace WebLottery.Infrastructure.Implementations.Repositories;

public class UserRepository : IUserRepository
{
    public Task<UserModel> CreateUser(string username, string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> GetUser(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> UpdateUser(int userId, string? email, string? username, string? password)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel?> FindUserByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel?> FindUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task UserBudgetAdd(int userId, int currencyId, int amount)
    {
        throw new NotImplementedException();
    }

    public Task UserBudgetWithdraw(int userId, int currencyId, int amount)
    {
        throw new NotImplementedException();
    }
}