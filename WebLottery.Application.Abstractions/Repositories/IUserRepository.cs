using Models.Users;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUserByUsername(string username);
}