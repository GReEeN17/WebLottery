using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.ServiceAbstractions;

public interface IPocketTicketService
{
    Task<PocketTicketModel> CreatePocketTicket(PocketTicketModel pocketTicketModel);
    PocketTicketModel GetPocketTicket(Guid pocketTicketId);
    Task UpdatePocketTicket(PocketTicketModel pocketTicketModel);
    Task DeletePocketTicket(Guid pocketTicketId);
    UserModel GetUserFromTicket(Guid ticketId);
}