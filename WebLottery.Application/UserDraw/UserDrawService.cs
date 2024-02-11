using Models.Draws;
using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.UserDraw;

namespace WebLottery.Application.UserDraw;

public class UserDrawService : IUserDrawService
{
    private readonly IUserDrawRepository _userDrawRepository;

    public UserDrawService(
        IUserDrawRepository userDrawRepository)
    {
        _userDrawRepository = userDrawRepository;
    }
    
    public void CreateUserDraw(Guid userId, Guid drawId)
    {
        _userDrawRepository.CreateUserDraw(userId, drawId);
    }

    public IEnumerable<Draw> GetUserDraws(Guid userId)
    {
        return _userDrawRepository.GetUserDraws(userId).ToBlockingEnumerable();
    }
}