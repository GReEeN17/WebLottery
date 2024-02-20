using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Draw;
using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Ticket;

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

    public DrawModel GetDraw(int drawId)
    {
        return _drawRepository.GetDraw(drawId).Result;
    }

    public IEnumerable<TicketModel> GetNotBoughtTickets(int drawId)
    {
        return _drawRepository.GetNotBoughtTickets(drawId).ToBlockingEnumerable();
    }

    public IEnumerable<DrawModel> GetCurrentDraws()
    {
        return _drawRepository.GetCurrentDraws().ToBlockingEnumerable();
    }
}