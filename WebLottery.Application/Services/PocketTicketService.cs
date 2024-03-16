using AutoMapper;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebLottery.Application.Services;

public class PocketTicketService(IDbRepository dbRepository, IMapper mapper) : IPocketTicketService
{
    public async Task<string> CreatePocketTicket(PocketTicketModel pocketTicketModel)
    {
        var pocketTicketEntity = mapper.Map<PocketTicketEntity>(pocketTicketModel);

        var result = await dbRepository.Add(pocketTicketEntity);
        await dbRepository.SaveChangesAsync();

        return JsonSerializer.Serialize(result);
    }

    public string GetPocketTicket(int pocketTicketId)
    {
        var pocketTicketEntity = dbRepository.Get<PocketTicketEntity>().FirstOrDefault(x => x.Id == pocketTicketId);
        var pocketTicketModel = mapper.Map<PocketTicketModel>(pocketTicketEntity);

        return JsonSerializer.Serialize(pocketTicketModel);
    }

    public async Task UpdatePocketTicket(PocketTicketModel pocketTicketModel)
    {
        var pocketTicketEntity = mapper.Map<PocketTicketEntity>(pocketTicketModel);

        await dbRepository.Update(pocketTicketEntity);
        await dbRepository.SaveChangesAsync();
    }

    public async Task DeletePocketTicket(int pocketTicketId)
    {
        await dbRepository.Delete<PocketTicketEntity>(pocketTicketId);
        await dbRepository.SaveChangesAsync();
    }
}