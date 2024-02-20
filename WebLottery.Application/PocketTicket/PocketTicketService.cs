using System.Runtime.CompilerServices;
using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.PocketTicket;
using WebLottery.Application.Contracts.Ticket;
using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.PocketTicket;
using WebLottery.Application.Models.Ticket;

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

    public IEnumerable<DrawModel> GetAllUserDraws(int pocketId)
    {
        IEnumerable<PocketTicketModel> tickets =
            _pocketTicketRepository.GetPocketTickets(pocketId).ToBlockingEnumerable();

        HashSet<DrawModel> draws = new HashSet<DrawModel>();

        foreach (PocketTicketModel ticket in tickets)
        {
            draws.Add(_ticketService.GetUserDraw(ticket.Id));
        }

        return draws.ToList();
    }
}