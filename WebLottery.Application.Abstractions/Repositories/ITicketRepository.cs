using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Abstractions.Repositories;

public interface ITicketRepository
{
    Task<TicketModel> CreateTicket(int drawId, int luckyNumber);
}