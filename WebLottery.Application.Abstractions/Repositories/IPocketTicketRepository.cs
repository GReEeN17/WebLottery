namespace WebLottery.Application.Abstractions.Repositories;

public interface IPocketTicketRepository
{
    Task CreatePocketTicket(Guid pocketId, Guid ticketId);
}