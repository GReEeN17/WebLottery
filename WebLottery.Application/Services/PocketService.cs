using System.Text.Json;
using AutoMapper;
using WebLottery.Application.Contracts.Pocket;
using WebLottery.Application.Models.Pocket;
using WebLottery.Infrastructure.Entities.Pocket;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.Pocket;

public class PocketService : IPocketService
{
    private readonly IDbRepository _dbRepository;
    private readonly IMapper _mapper;

    public PocketService(IDbRepository dbRepository, IMapper mapper)
    {
        _dbRepository = dbRepository;
        _mapper = mapper;
    }
    
    public async Task<string> CreatePocket(PocketModel pocketModel)
    {
        var pocketEntity = _mapper.Map<PocketEntity>(pocketModel);
        
        var pocketEntityResult = await _dbRepository.Add(pocketEntity);
        await _dbRepository.SaveChangesAsync();

        var result = new
        {
            Id = pocketEntityResult.Id,
            UserId = pocketEntityResult.UserId
        };

        return JsonSerializer.Serialize(result);
    }

    public string GetPocket(int pocketId)
    {
        var pocketEntity = _dbRepository.Get<PocketEntity>().FirstOrDefault(x => x.Id == pocketId);
        var pocketModel = _mapper.Map<PocketModel>(pocketEntity);

        return JsonSerializer.Serialize(pocketModel);
    }

    public async Task UpdatePocket(PocketModel pocketModel)
    {
        var pocketEntity = _mapper.Map<PocketEntity>(pocketModel);

        await _dbRepository.Update(pocketEntity);
        await _dbRepository.SaveChangesAsync();
    }

    public async Task DeletePocket(int pocketId)
    {
        await _dbRepository.Delete<PocketEntity>(pocketId);
        await _dbRepository.SaveChangesAsync();
    }
}