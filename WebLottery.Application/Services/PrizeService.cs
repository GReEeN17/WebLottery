using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.Services;

public class PrizeService(
    IDbRepository dbRepository,
    IMapper mapper) : IPrizeService
{
    public async Task<string> CreatePrize(PrizeModel prizeModel)
    {
        var prizeEntity = mapper.Map<PrizeEntity>(prizeModel);
        
        var result = await dbRepository.Add(prizeEntity);
        await dbRepository.SaveChangesAsync();
        
        return JsonSerializer.Serialize(result);
    }

    public string GetPrize(Guid prizeId)
    {
        var prizeEntity = dbRepository.Get<PrizeEntity>().Include(x => x.Currency).FirstOrDefault(x => x.Id == prizeId);
        
        if (prizeEntity == null)
        {
            return String.Empty;
        }
        
        var prizeModel = mapper.Map<PrizeModel>(prizeEntity);
        
        return JsonSerializer.Serialize(prizeModel);
    }
    
    public IEnumerable<PrizeEntity> GetAllPrizes()
    {
        return dbRepository.GetAll<PrizeEntity>().Include(x => x.Currency).ToList();
    }

    public async Task UpdatePrize(PrizeModel prizeModel)
    {
        var prizeEntity = mapper.Map<PrizeEntity>(prizeModel);
        
        await dbRepository.Update(prizeEntity);
        await dbRepository.SaveChangesAsync();
    }

    public async Task DeletePrize(Guid prizeId)
    {
        await dbRepository.Delete<PrizeEntity>(prizeId);
        await dbRepository.SaveChangesAsync();
    }
}