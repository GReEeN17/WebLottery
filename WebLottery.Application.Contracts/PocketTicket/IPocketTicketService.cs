using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.PocketTicket;

namespace WebLottery.Application.Contracts.PocketTicket;

public interface IPocketTicketService
{
    Task<string> CreatePocketTicket(int pocketId, int ticketId);
    Task<string> GetPocketTicket(int pocketTicketId);
    Task UpdatePocketTicket(int pocketTicketId, int? pocketId, int? ticketId);
    Task DeletePocketTicket(int pocketTicketId);
}