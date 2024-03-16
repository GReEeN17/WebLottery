using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IPocketTicketService
{
    Task<string> CreatePocketTicket(PocketTicketModel pocketTicketModel);
    string GetPocketTicket(int pocketTicketId);
    Task UpdatePocketTicket(PocketTicketModel pocketTicketModel);
    Task DeletePocketTicket(int pocketTicketId);
}