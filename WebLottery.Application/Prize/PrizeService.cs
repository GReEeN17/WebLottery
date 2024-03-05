using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebLottery.Application.Contracts.Prize;
using WebLottery.Application.Models.Prize;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Entities.Prize;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.Prize;

public class PrizeService : IPrizeService
{
    private readonly IDbRepository _dbRepository;
    private readonly IMapper _mapper;

    public PrizeService(
        IDbRepository dbRepository,
        IMapper mapper)
    {
        _dbRepository = dbRepository;
        _mapper = mapper;
    }
    
    public async Task<string> CreatePrize(PrizeModel prizeModel)
    {
        var prizeEntity = _mapper.Map<PrizeEntity>(prizeModel);
        
        var result = await _dbRepository.Add(prizeEntity);
        await _dbRepository.SaveChangesAsync();
        
        return JsonSerializer.Serialize(result);
    }

    public string GetPrize(int prizeId)
    {
        var prizeEntity = _dbRepository.Get<PrizeEntity>().Include(x => x.Currency).FirstOrDefault(x => x.Id == prizeId);
        
        if (prizeEntity == null)
        {
            return String.Empty;
        }
        
        var prizeModel = _mapper.Map<PrizeModel>(prizeEntity);
        
        return JsonSerializer.Serialize(prizeModel);
    }

    public Task UpdatePrize(PrizeModel prizeModel)
    {
        var prizeEntity = _mapper.Map<PrizeEntity>(prizeModel);
        
        var result = _dbRepository.Update(prizeEntity);
        return _dbRepository.SaveChangesAsync();
    }

    public Task DeletePrize(int prizeId)
    {
        throw new NotImplementedException();
    }
}