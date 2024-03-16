using AutoMapper;
using WebLottery.Application.Contracts.Currency;
using WebLottery.Application.Models.Currency;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Implementations.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebLottery.Application.Currency;

public class CurrencyService : ICurrencyService
{
    private readonly IDbRepository _dbRepository;
    private readonly IMapper _mapper;

    public CurrencyService(
        IDbRepository dbRepository,
        IMapper mapper)
    {
        _dbRepository = dbRepository;
        _mapper = mapper;
    }
    
     public async Task<string> CreateCurrency(CurrencyModel currencyModel)
     {
         var currencyEntity = _mapper.Map<CurrencyEntity>(currencyModel);
         
         var result = await _dbRepository.Add(currencyEntity);
         await _dbRepository.SaveChangesAsync();

         return JsonSerializer.Serialize(result);
     }

    public string GetCurrency(int currencyId)
    {
        var currencyEntity = _dbRepository.Get<CurrencyEntity>().FirstOrDefault(x => x.Id == currencyId);
        var currencyModel = _mapper.Map<CurrencyModel>(currencyEntity);

        return JsonSerializer.Serialize(currencyModel);
    }

    public string GetAllCurrencies()
    {
        var currencies = _dbRepository.GetAll<CurrencyEntity>().ToList();
        var currencyModels = _mapper.Map<List<CurrencyModel>>(currencies);

        return JsonSerializer.Serialize(currencyModels);
    }

    public async Task UpdateCurrency(CurrencyModel currencyModel)
    {
        var currencyEntity = _mapper.Map<CurrencyEntity>(currencyModel);
        
        await _dbRepository.Update(currencyEntity);
        await _dbRepository.SaveChangesAsync();
    }

    public async Task DeleteCurrency(int currencyId)
    {
        await _dbRepository.Delete<CurrencyEntity>(currencyId);
        await _dbRepository.SaveChangesAsync();
    }
}