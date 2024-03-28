using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebLottery.Application.Services;

public class PocketTicketService(IDbRepository dbRepository, IMapper mapper) : IPocketTicketService
{
    public async Task<PocketTicketModel> CreatePocketTicket(PocketTicketModel pocketTicketModel)
    {
        var pocketTicketEntity = mapper.Map<PocketTicketEntity>(pocketTicketModel);

        var result = await dbRepository.Add(pocketTicketEntity);
        await dbRepository.SaveChangesAsync();
        
        return mapper.Map<PocketTicketModel>(result);
    }

    public PocketTicketModel GetPocketTicket(Guid pocketTicketId)
    {
        var pocketTicketEntity = dbRepository.Get<PocketTicketEntity>().FirstOrDefault(x => x.Id == pocketTicketId);
        var pocketTicketModel = mapper.Map<PocketTicketModel>(pocketTicketEntity);

        return pocketTicketModel;
    }

    public async Task UpdatePocketTicket(PocketTicketModel pocketTicketModel)
    {
        var pocketTicketEntity = mapper.Map<PocketTicketEntity>(pocketTicketModel);

        await dbRepository.Update(pocketTicketEntity);
        await dbRepository.SaveChangesAsync();
    }

    public async Task DeletePocketTicket(Guid pocketTicketId)
    {
        await dbRepository.Delete<PocketTicketEntity>(pocketTicketId);
        await dbRepository.SaveChangesAsync();
    }
    
    public UserModel GetUserFromTicket(Guid ticketId)
    {
        var pocketTicket = dbRepository.Get<PocketTicketEntity>()
            .Include(pocketTicket => pocketTicket.Pocket)
            .ThenInclude(pocket => pocket.User)
            .ThenInclude(user => user.Wallet)
            .ThenInclude(wallet => wallet.WalletCurrencies)
            .FirstOrDefault(pocketTicket => pocketTicket.Ticket.Id == ticketId);

        return mapper.Map<UserModel>(pocketTicket!.Pocket.User);
    }
}