using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Ticket;

namespace WebLottery.Application.Contracts.Draw;

public interface IDrawService
{
    Task<string> CreateDraw(int ticketPrice, int maxAmountPlayers);
    Task<string> GetDraw(int drawId);
    Task UpdateDraw(int drawId, int? ticketPrice, int? maxAmountPlayers);
    Task DeleteDraw(int drawId);
}