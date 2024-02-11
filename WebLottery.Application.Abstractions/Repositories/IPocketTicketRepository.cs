namespace WebLottery.Application.Abstractions.Repositories;

public interface IPocketTicketRepository
{
    Task CreatePocketTicket(int pocketId, int ticketId);
}