using WebLottery.Application.Models.PocketTicket;

namespace WebLottery.Application.Abstractions.Repositories;

public interface IPocketTicketRepository
{
    Task<PocketTicketModel> CreatePocketTicket(int pocketId, int ticketId);
    IAsyncEnumerable<PocketTicketModel> GetPocketTickets(int pocketId);
}