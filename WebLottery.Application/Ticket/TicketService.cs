using WebLottery.Application.Contracts.Ticket;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Ticket;

public class TicketService : ITicketService
{
    public Task<string> CreateTicket(TicketModel ticketModel)
    {
        throw new NotImplementedException();
    }

    public string GetTicket(int ticketId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTicket(TicketModel ticketModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTicket(int ticketId)
    {
        throw new NotImplementedException();
    }
}