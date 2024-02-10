using Models.Users;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task CreateUser(string username, string email, string password);
    User? FindUserByUsername(string username);
    Task UpdateUserBudget(Guid userId, Guid currencyId, int amount);
}