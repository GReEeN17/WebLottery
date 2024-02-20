using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Contracts.Draw;

public interface IDrawService
{
    void CreateDraw(int ticketPrice, int maxAmountPlayers);
    void EndDraw(int drawId);
    DrawModel GetDraw(int drawId);
    IEnumerable<TicketModel> GetNotBoughtTickets(int drawId);
    IEnumerable<DrawModel> GetCurrentDraws();
}