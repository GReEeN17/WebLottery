using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Defaults;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebLottery.Application.Services;

public class DrawService(
    IDbRepository dbRepository,
    ITicketService ticketService,
    IPrizeService prizeService,
    IMapper mapper) : IDrawService
{
    public async Task<DrawEntity> CreateDraw(DrawModel drawModel)
    {
        var drawEntity = mapper.Map<DrawEntity>(drawModel);
        
        Random random = new Random();

        var prizes = prizeService.GetAllPrizes().ToList();
        drawEntity.PrizeId = prizes.ElementAt(random.Next(0, prizes.Count)).Id;
        
        var drawEntityResult = await dbRepository.Add(drawEntity);
        await dbRepository.SaveChangesAsync();
        
        HashSet<int> uniqueNumbers = new HashSet<int>();
        
        while (uniqueNumbers.Count < drawEntityResult.MaxAmountPlayers)
        {
            uniqueNumbers.Add(random.Next(1, ServiceDefaults.MaxPlayersAmount.GetServiceDefaultMaxPlayersAmount()));
        }
        
        foreach (var ticketModel in uniqueNumbers.Select(number => new TicketModel
                 {
                     DrawId = drawEntityResult.Id,
                     LuckyNumber = number,
                     PurchaseTime = null
                 }))
        {
            await ticketService.CreateTicket(ticketModel);
        }
        
        return drawEntity;
    }

    public DrawEntity? GetDraw(Guid drawId)
    {
        return dbRepository.Get<DrawEntity>().Include(x => x.Prize).FirstOrDefault(x => x.Id == drawId);
    }

    public string GetALlDraws()
    {
        var drawEntities = dbRepository.GetAll<DrawEntity>().Include(x => x.Prize).ToList();
        var drawModels = mapper.Map<List<DrawModel>>(drawEntities);

        return JsonSerializer.Serialize(drawModels);
    }

    public string GetSomeDraws(int count)
    {
        var drawEntities = dbRepository.Get<DrawEntity>().Include(x => x.Prize).Take(count).ToList();
        var drawModels = mapper.Map<List<DrawModel>>(drawEntities);
        
        return JsonSerializer.Serialize(drawModels);
    }

    public async Task UpdateDraw(DrawModel drawModel)
    {
        var drawEntity = mapper.Map<DrawEntity>(drawModel);

        await dbRepository.Update(drawEntity);
        await dbRepository.SaveChangesAsync();
    }

    public async Task DeleteDraw(Guid drawId)
    {
        await dbRepository.Delete<DrawEntity>(drawId);
        await dbRepository.SaveChangesAsync();
    }
}