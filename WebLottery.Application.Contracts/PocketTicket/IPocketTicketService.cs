namespace WebLottery.Application.Contracts.PocketTicket;

public interface IPocketTicketService
{
    void CreatePocketTicket(int pocketId, int ticketId);
    IEnumerable<Models.PocketTicket.PocketTicket> GetAllUserPocketTickets(int pocketId);
}