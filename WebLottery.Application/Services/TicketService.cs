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
    public async Task<TicketEntity> CreateTicket(TicketModel ticketModel)
    {
        var ticketEntity = mapper.Map<TicketEntity>(ticketModel);

        var result = await dbRepository.Add(ticketEntity);
        await dbRepository.SaveChangesAsync();

        return result;
    }

    public string GetTicket(Guid ticketId)
    {
        var ticketEntity = dbRepository.Get<TicketEntity>().Include(x => x.Draw).FirstOrDefault(x => x.Id == ticketId);
        
        if (ticketEntity == null)
        {
            return String.Empty;
        }
        
        var ticketModel = mapper.Map<TicketModel>(ticketEntity);
        
        return JsonSerializer.Serialize(ticketModel);
    }

    public async Task BuyTicket(Guid ticketId)
    {
        var ticketEntity = dbRepository.Get<TicketEntity>().First(x => x.Id == ticketId);
        ticketEntity.PurchaseTime = DateTime.UtcNow;
        
        await dbRepository.Update(ticketEntity);
        await dbRepository.SaveChangesAsync();
    }

    public IEnumerable<TicketModel> GetNotPurchasedDrawTickets(Guid drawId)
    {
        var ticketEntities = dbRepository.Get<TicketEntity>().Include(x => x.Draw).Where(x => x.DrawId == drawId && x.PurchaseTime == DateTime.Parse("0001-01-01T00:00:00")).ToList();
        var ticketModels = mapper.Map<List<TicketModel>>(ticketEntities);
        
        return ticketModels;
    }

    public IEnumerable<TicketModel> GetPurchasedDrawTickets(Guid drawId)
    {
        var ticketEntities = dbRepository.Get<TicketEntity>()
            .Include(ticket => ticket.Draw)
            .ThenInclude(draw => draw.Prize)
            .ThenInclude(prize => prize.Currency)
            .Where(ticket => ticket.DrawId == drawId && ticket.PurchaseTime != DateTime.Parse("0001-01-01T00:00:00")).ToList();
        var ticketModels = mapper.Map<List<TicketModel>>(ticketEntities);

        return ticketModels;
    }

    public async Task UpdateTicket(TicketModel ticketModel)
    {
        var ticketEntity = mapper.Map<TicketEntity>(ticketModel);

        await dbRepository.Update(ticketEntity);
        await dbRepository.SaveChangesAsync();
    }

    public async Task DeleteTicket(Guid ticketId)
    {
        await dbRepository.Delete<TicketEntity>(ticketId);
        await dbRepository.SaveChangesAsync();
    }
}