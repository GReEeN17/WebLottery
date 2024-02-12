using Models.Users;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User> CreateUser(string username, string email, string password);
    Task<User?> FindUserByUsername(string username);
    Task<User?> FindUserByEmail(string email);
    Task UserBudgetAdd(int userId, int currencyId, int amount);
    Task UserBudgetWithdraw(int userId, int currencyId, int amount);
}