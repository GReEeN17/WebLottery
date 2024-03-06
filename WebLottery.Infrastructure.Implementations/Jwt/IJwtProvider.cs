using WebLottery.Infrastructure.Entities.User;

namespace WebLottery.Infrastructure.Implementations.Jwt;

public interface IJwtProvider
{
    string GenerateToken(UserEntity userEntity);
}