using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLottery.Application.Contracts.Ticket;
using WebLottery.Application.Models.Ticket;
using WebLottery.Infrastructure.Entities.Prize;
using WebLottery.Infrastructure.Entities.Ticket;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.Ticket;

public class TicketService : ITicketService
{
    private readonly IDbRepository _dbRepository;
    private readonly IMapper _mapper;

    public TicketService(IDbRepository dbRepository, IMapper mapper)
    {
        _dbRepository = dbRepository;
        _mapper = mapper;
    }
    
    public async Task<string> CreateTicket(TicketModel ticketModel)
    {
        var ticketEntity = _mapper.Map<TicketEntity>(ticketModel);

        var result = await _dbRepository.Add(ticketEntity);
        await _dbRepository.SaveChangesAsync();

        return JsonSerializer.Serialize(result);
    }

    public string GetTicket(int ticketId)
    {
        var ticketEntity = _dbRepository.Get<TicketEntity>().Include(x => x.Draw).FirstOrDefault(x => x.Id == ticketId);
        
        if (ticketEntity == null)
        {
            return String.Empty;
        }
        
        var ticketModel = _mapper.Map<TicketModel>(ticketEntity);
        
        return JsonSerializer.Serialize(ticketModel);
    }

    public string GetDrawTickets(int drawId)
    {
        var ticketEntities = _dbRepository.Get<TicketEntity>().Include(x => x.Draw).Where(x => x.DrawId == drawId).ToList();
        var ticketModels = _mapper.Map<List<TicketModel>>(ticketEntities);
        
        return JsonSerializer.Serialize(ticketModels);
    }

    public async Task UpdateTicket(TicketModel ticketModel)
    {
        var ticketEntity = _mapper.Map<TicketEntity>(ticketModel);

        await _dbRepository.Update(ticketEntity);
        await _dbRepository.SaveChangesAsync();
    }

    public async Task DeleteTicket(int ticketId)
    {
        await _dbRepository.Delete<TicketEntity>(ticketId);
        await _dbRepository.SaveChangesAsync();
    }
}