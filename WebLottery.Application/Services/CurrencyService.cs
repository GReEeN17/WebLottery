using AutoMapper;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebLottery.Application.Services;

public class CurrencyService(
    IDbRepository dbRepository,
    IMapper mapper) : ICurrencyService
{
    public async Task<string> CreateCurrency(CurrencyModel currencyModel)
     {
         var currencyEntity = mapper.Map<CurrencyEntity>(currencyModel);
         
         var result = await dbRepository.Add(currencyEntity);
         await dbRepository.SaveChangesAsync();

         return JsonSerializer.Serialize(result);
     }

    public string GetCurrency(Guid currencyId)
    {
        var currencyEntity = dbRepository.Get<CurrencyEntity>().FirstOrDefault(x => x.Id == currencyId);
        var currencyModel = mapper.Map<CurrencyModel>(currencyEntity);

        return JsonSerializer.Serialize(currencyModel);
    }

    public string GetAllCurrencies()
    {
        var currencies = dbRepository.GetAll<CurrencyEntity>().ToList();
        var currencyModels = mapper.Map<List<CurrencyModel>>(currencies);

        return JsonSerializer.Serialize(currencyModels);
    }

    public async Task UpdateCurrency(CurrencyModel currencyModel)
    {
        var currencyEntity = mapper.Map<CurrencyEntity>(currencyModel);
        
        await dbRepository.Update(currencyEntity);
        await dbRepository.SaveChangesAsync();
    }

    public async Task DeleteCurrency(Guid currencyId)
    {
        await dbRepository.Delete<CurrencyEntity>(currencyId);
        await dbRepository.SaveChangesAsync();
    }
}