using Models.Users;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task CreateUser(string username, string email, string password);
    Task<User?> FindUserByUsername(string username);
    Task<User?> FindUserByEmail(string email);
    Task UpdateUserBudget(Guid userId, Guid currencyId, int amount);
}