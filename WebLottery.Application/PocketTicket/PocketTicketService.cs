using WebLottery.Application.Contracts.PocketTicket;
using WebLottery.Application.Models.PocketTicket;

namespace WebLottery.Application.PocketTicket;

public class PocketTicketService : IPocketTicketService
{
    public Task<string> CreatePocketTicket(PocketTicketModel pocketTicketModel)
    {
        throw new NotImplementedException();
    }

    public string GetPocketTicket(int pocketTicketId)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePocketTicket(PocketTicketModel pocketTicketModel)
    {
        throw new NotImplementedException();
    }

    public Task DeletePocketTicket(int pocketTicketId)
    {
        throw new NotImplementedException();
    }
}