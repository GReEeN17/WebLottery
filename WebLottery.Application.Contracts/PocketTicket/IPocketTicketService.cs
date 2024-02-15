using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.Contracts.PocketTicket;

public interface IPocketTicketService
{
    void CreatePocketTicket(int pocketId, int ticketId);
    IEnumerable<Models.PocketTicket.PocketTicketModel> GetAllUserPocketTickets(int pocketId);
    IEnumerable<DrawModel> GetAllUserDraws(int pocketId);
}