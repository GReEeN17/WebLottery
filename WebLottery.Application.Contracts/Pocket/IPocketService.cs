using WebLottery.Application.Models.Draw;

namespace WebLottery.Application.Contracts.Pocket;

public interface IPocketService
{
    void CreatePocket(int userId);
    int GetUserPocket(int userId);
    void BuyTicket(int userId, int luckyNumber, int drawId);
    IEnumerable<Models.PocketTicket.PocketTicketModel> GetAllUserPocketTickets(int userId);
    IEnumerable<DrawModel> GetAllUserDraws(int userId);
}