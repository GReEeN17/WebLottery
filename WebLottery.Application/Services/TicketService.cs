using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.Services;

public class TicketService(IDbRepository dbRepository, IMapper mapper) : ITicketService
{
    public async Task<string> CreateTicket(TicketModel ticketModel)
    {
        var ticketEntity = mapper.Map<TicketEntity>(ticketModel);

        var result = await dbRepository.Add(ticketEntity);
        await dbRepository.SaveChangesAsync();

        return JsonSerializer.Serialize(result);
    }

    public string GetTicket(int ticketId)
    {
        var ticketEntity = dbRepository.Get<TicketEntity>().Include(x => x.Draw).FirstOrDefault(x => x.Id == ticketId);
        
        if (ticketEntity == null)
        {
            return String.Empty;
        }
        
        var ticketModel = mapper.Map<TicketModel>(ticketEntity);
        
        return JsonSerializer.Serialize(ticketModel);
    }

    public string GetDrawTickets(int drawId)
    {
        var ticketEntities = dbRepository.Get<TicketEntity>().Include(x => x.Draw).Where(x => x.DrawId == drawId).ToList();
        var ticketModels = mapper.Map<List<TicketModel>>(ticketEntities);
        
        return JsonSerializer.Serialize(ticketModels);
    }

    public async Task UpdateTicket(TicketModel ticketModel)
    {
        var ticketEntity = mapper.Map<TicketEntity>(ticketModel);

        await dbRepository.Update(ticketEntity);
        await dbRepository.SaveChangesAsync();
    }

    public async Task DeleteTicket(int ticketId)
    {
        await dbRepository.Delete<TicketEntity>(ticketId);
        await dbRepository.SaveChangesAsync();
    }
}