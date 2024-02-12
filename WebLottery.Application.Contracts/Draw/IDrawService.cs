namespace WebLottery.Application.Contracts.Draws;

public interface IDrawService
{
    void CreateDraw(int ticketPrice, int maxAmountPlayers);
    void EndDraw(int drawId);
}