namespace WebLottery.Application.Contracts.Draw;

public interface IDrawService
{
    void CreateDraw(int ticketPrice, int maxAmountPlayers);
    void EndDraw(int drawId);
}