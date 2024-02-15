using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.PocketTicket;
using WebLottery.Application.Contracts.Ticket;
using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.PocketTicket;

public class PocketTicketService : IPocketTicketService
{
    private readonly IPocketTicketRepository _pocketTicketRepository;
    private readonly ITicketService _ticketService;

    public PocketTicketService(
        IPocketTicketRepository pocketTicketRepository,
        ITicketService ticketService)
    {
        _pocketTicketRepository = pocketTicketRepository;
        _ticketService = ticketService;
    }
    
    public void CreatePocketTicket(int pocketId, int ticketId)
    {
        _pocketTicketRepository.CreatePocketTicket(pocketId, ticketId);
    }

    public IEnumerable<Models.PocketTicket.PocketTicketModel> GetAllUserPocketTickets(int pocketId)
    {
        return _pocketTicketRepository.GetAllUserPocketTickets(pocketId).ToBlockingEnumerable();
    }

    public IEnumerable<DrawModel> GetAllUserDraws(int pocketId)
    {
        throw new NotImplementedException();
    }
}