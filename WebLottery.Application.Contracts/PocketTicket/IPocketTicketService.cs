using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.PocketTicket;

namespace WebLottery.Application.Contracts.PocketTicket;

public interface IPocketTicketService
{
    Task<string> CreatePocketTicket(PocketTicketModel pocketTicketModel);
    string GetPocketTicket(int pocketTicketId);
    Task UpdatePocketTicket(PocketTicketModel pocketTicketModel);
    Task DeletePocketTicket(int pocketTicketId);
}