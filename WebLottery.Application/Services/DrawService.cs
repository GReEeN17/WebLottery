using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebLottery.Application.Services;

public class DrawService(
    IDbRepository dbRepository,
    IMapper mapper) : IDrawService
{
    public async Task<string> CreateDraw(DrawModel drawModel)
    {
        var drawEntity = mapper.Map<DrawEntity>(drawModel);
        
        var result = await dbRepository.Add(drawEntity);
        await dbRepository.SaveChangesAsync();
        
        return JsonSerializer.Serialize(result);
    }

    public string GetDraw(Guid drawId)
    {
        var drawEntity = dbRepository.Get<DrawEntity>().Include(x => x.Prize).FirstOrDefault(x => x.Id == drawId);
        var drawModel = mapper.Map<DrawModel>(drawEntity);

        return JsonSerializer.Serialize(drawModel);
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