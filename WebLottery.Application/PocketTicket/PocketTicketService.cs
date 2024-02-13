using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.PocketTicket;

namespace WebLottery.Application.PocketTicket;

public class PocketTicketService : IPocketTicketService
{
    private readonly IPocketTicketRepository _pocketTicketRepository;

    public PocketTicketService(
        IPocketTicketRepository pocketTicketRepository)
    {
        _pocketTicketRepository = pocketTicketRepository;
    }
    
    public void CreatePocketTicket(int pocketId, int ticketId)
    {
        _pocketTicketRepository.CreatePocketTicket(pocketId, ticketId);
    }

    public IEnumerable<Models.PocketTicket.PocketTicketModel> GetAllUserPocketTickets(int pocketId)
    {
        return _pocketTicketRepository.GetAllUserPocketTickets(pocketId).ToBlockingEnumerable();
    }
}