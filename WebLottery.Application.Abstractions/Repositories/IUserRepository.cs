using WebLottery.Application.Models.User;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<UserModel> CreateUser(string username, string email, string password);
    Task<UserModel> GetUser(int userId);
    Task<UserModel> UpdateUser(int userId, string? email, string? username, string? password);
    Task<UserModel?> FindUserByUsername(string username);
    Task<UserModel?> FindUserByEmail(string email);
    Task UserBudgetAdd(int userId, int currencyId, int amount);
    Task UserBudgetWithdraw(int userId, int currencyId, int amount);
}