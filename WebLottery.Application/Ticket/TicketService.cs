using WebLottery.Application.Abstractions.Repositories;
using WebLottery.Application.Contracts.Ticket;
using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Ticket;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(
        ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }
    
    public void CreateTicket(int drawId, int luckyNumber)
    {
        _ticketRepository.CreateTicket(drawId, luckyNumber);
    }

    public TicketModel UpdateTicket(int ticketId)
    {
        return _ticketRepository.UpdateTicket(ticketId).Result;
    }

    public DrawModel GetUserDraw(int ticketId)
    {
        return _ticketRepository.GetTicket(ticketId).Result.Draw;
    }
}