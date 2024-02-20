using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Draw;
using WebLottery.Application.Contracts.Pocket;
using WebLottery.Application.Contracts.PocketTicket;
using WebLottery.Application.Contracts.Ticket;
using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Pocket;

public class PocketService : IPocketService
{
    private readonly IPocketRepository _pocketRepository;
    private readonly IPocketTicketService _pocketTicketService;
    private readonly IDrawService _drawService;
    private readonly ITicketService _ticketService;

    public PocketService(
        IPocketRepository pocketRepository,
        IPocketTicketService pocketTicketService,
        IDrawService drawService,
        ITicketService ticketService)
    {
        _pocketRepository = pocketRepository;
        _pocketTicketService = pocketTicketService;
        _drawService = drawService;
        _ticketService = ticketService;
    }
    public void CreatePocket(int userId)
    {
        _pocketRepository.CreatePocket(userId);
    }

    public void BuyTicket(int userId, int drawId)
    {
        Random random = new Random();
        List<TicketModel> tickets = _drawService.GetNotBoughtTickets(drawId).ToList();
        int randomIndex = random.Next(tickets.Count == 0 ? 0 : tickets.Count - 1);
        TicketModel userTicket = tickets[randomIndex];

        int pocketId = _pocketRepository.GetPocket(userId).Result.Id;
        
        _pocketTicketService.CreatePocketTicket(pocketId, userTicket.Id);
        _ticketService.UpdateTicket(userTicket.Id);
    }

    public IEnumerable<DrawModel> GetAllUserDraws(int userId)
    {
        int pocketId = _pocketRepository.GetPocket(userId).Result.Id;
        return _pocketTicketService.GetAllUserDraws(pocketId);
    }
}