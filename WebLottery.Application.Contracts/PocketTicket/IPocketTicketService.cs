using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.Contracts.PocketTicket;

public interface IPocketTicketService
{
    void CreatePocketTicket(int pocketId, int ticketId);
    IEnumerable<DrawModel> GetAllUserDraws(int pocketId);
}