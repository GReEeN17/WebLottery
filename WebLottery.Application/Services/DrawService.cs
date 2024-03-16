using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebLottery.Application.Services;

public class DrawService : IDrawService
{
    private readonly IDbRepository _dbRepository;
    private readonly IMapper _mapper;

    public DrawService(
        IDbRepository dbRepository,
        IMapper mapper)
    {
        _dbRepository = dbRepository;
        _mapper = mapper;
    }
    public async Task<string> CreateDraw(DrawModel drawModel)
    {
        var drawEntity = _mapper.Map<DrawEntity>(drawModel);
        
        var result = await _dbRepository.Add(drawEntity);
        await _dbRepository.SaveChangesAsync();
        
        return JsonSerializer.Serialize(result);
    }

    public string GetDraw(int drawId)
    {
        var drawEntity = _dbRepository.Get<DrawEntity>().Include(x => x.Prize).FirstOrDefault(x => x.Id == drawId);
        var drawModel = _mapper.Map<DrawModel>(drawEntity);

        return JsonSerializer.Serialize(drawModel);
    }

    public string GetALlDraws()
    {
        var drawEntities = _dbRepository.GetAll<DrawEntity>().Include(x => x.Prize).ToList();
        var drawModels = _mapper.Map<List<DrawModel>>(drawEntities);

        return JsonSerializer.Serialize(drawModels);
    }

    public string GetSomeDraws(int count)
    {
        var drawEntities = _dbRepository.Get<DrawEntity>().Include(x => x.Prize).Take(count).ToList();
        var drawModels = _mapper.Map<List<DrawModel>>(drawEntities);
        
        return JsonSerializer.Serialize(drawModels);
    }

    public async Task UpdateDraw(DrawModel drawModel)
    {
        var drawEntity = _mapper.Map<DrawEntity>(drawModel);

        await _dbRepository.Update(drawEntity);
        await _dbRepository.SaveChangesAsync();
    }

    public async Task DeleteDraw(int drawId)
    {
        await _dbRepository.Delete<DrawEntity>(drawId);
        await _dbRepository.SaveChangesAsync();
    }
}