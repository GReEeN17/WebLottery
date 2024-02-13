using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Pockets;
using WebLottery.Application.Contracts.PocketTicket;
using WebLottery.Application.Contracts.Tcikets;

namespace WebLottery.Application.Pocket;

public class PocketService : IPocketService
{
    private readonly IPocketRepository _pocketRepository;
    private readonly IPocketTicketService _pocketTicketService;
    private readonly ITicketService _ticketService;

    public PocketService(
        IPocketRepository pocketRepository,
        IPocketTicketService pocketTicketService,
        ITicketService ticketService)
    {
        _pocketRepository = pocketRepository;
        _pocketTicketService = pocketTicketService;
        _ticketService = ticketService;
    }
    public void CreatePocket(int userId)
    {
        _pocketRepository.CreatePocket(userId);
    }

    public int GetUserPocket(int userId)
    {
        return _pocketRepository.GetUserPocket(userId).Result;
    }

    public void BuyTicket(int userId, int luckyNumber, int drawId)
    {
        Models.Ticket.TicketModel newTicketEntity = _ticketService.CreateTicket(drawId, luckyNumber);
        int pocketId = _pocketRepository.GetUserPocket(userId).Result;
        _pocketTicketService.CreatePocketTicket(pocketId, newTicketEntity.Id);
    }

    public IEnumerable<Models.PocketTicket.PocketTicketModel> GetAllUserPocketTickets(int userId)
    {
        int pocketId = _pocketRepository.GetUserPocket(userId).Result;
        return _pocketTicketService.GetAllUserPocketTickets(pocketId);
    }
}