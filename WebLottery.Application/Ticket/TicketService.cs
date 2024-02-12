using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Tcikets;

namespace WebLottery.Application.Ticket;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(
        ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }
    
    public Models.Tickets.Ticket CreateTicket(int drawId, int luckyNumber)
    {
        return _ticketRepository.CreateTicket(drawId, luckyNumber).Result;
    }
}