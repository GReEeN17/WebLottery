using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Draws;

namespace WebLottery.Application.Draw;

public class DrawService : IDrawService
{
    private readonly IDrawRepository _drawRepository;

    public DrawService(
        IDrawRepository drawRepository)
    {
        _drawRepository = drawRepository;
    }
    
    public void CreateDraw(int ticketPrice, int maxAmountPlayers)
    {
        _drawRepository.CreateDraw(ticketPrice, maxAmountPlayers);
    }

    public void EndDraw(int drawId)
    {
        _drawRepository.EndDraw(drawId);
    }
}