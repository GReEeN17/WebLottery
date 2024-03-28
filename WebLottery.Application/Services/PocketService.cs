using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.Services;

public class PocketService(IDbRepository dbRepository, IMapper mapper) : IPocketService
{
    public async Task<string> CreatePocket(PocketModel pocketModel)
    {
        var pocketEntity = mapper.Map<PocketEntity>(pocketModel);
        
        var pocketEntityResult = await dbRepository.Add(pocketEntity);
        await dbRepository.SaveChangesAsync();

        var result = new
        {
            Id = pocketEntityResult.Id,
            UserId = pocketEntityResult.UserId
        };

        return JsonSerializer.Serialize(result);
    }

    public string GetPocket(Guid pocketId)
    {
        var pocketEntity = dbRepository.Get<PocketEntity>().FirstOrDefault(x => x.Id == pocketId);
        var pocketModel = mapper.Map<PocketModel>(pocketEntity);

        return JsonSerializer.Serialize(pocketModel);
    }

    public async Task UpdatePocket(PocketModel pocketModel)
    {
        var pocketEntity = mapper.Map<PocketEntity>(pocketModel);

        await dbRepository.Update(pocketEntity);
        await dbRepository.SaveChangesAsync();
    }

    public async Task DeletePocket(Guid pocketId)
    {
        await dbRepository.Delete<PocketEntity>(pocketId);
        await dbRepository.SaveChangesAsync();
    }
}