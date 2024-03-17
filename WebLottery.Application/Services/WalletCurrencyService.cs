using System.Text.Json;
using AutoMapper;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.Services;

public class WalletCurrencyService(IDbRepository dbRepository, IMapper mapper) : IWalletCurrencyService
{
    public async Task<string> CreateWalletCurrency(WalletCurrencyModel walletCurrencyModel)
    {
        var walletCurrencyEntity = mapper.Map<WalletCurrencyEntity>(walletCurrencyModel);
        
        var walletCurrencyEntityResult = await dbRepository.Add(walletCurrencyEntity);
        await dbRepository.SaveChangesAsync();

        var result = new
        {
            Id = walletCurrencyEntity.Id
        };

        return JsonSerializer.Serialize(result);
    }

    public string GetWalletCurrency(Guid walletCurrencyId)
    {
        var walletCurrencyEntity = dbRepository.Get<WalletCurrencyEntity>().FirstOrDefault(x => x.Id == walletCurrencyId);
        var walletCurrencyModel = mapper.Map<WalletCurrencyModel>(walletCurrencyEntity);

        return JsonSerializer.Serialize(walletCurrencyModel);
    }

    public async Task UpdateWalletCurrency(WalletCurrencyModel walletCurrencyModel)
    {
        var walletCurrencyEntity = mapper.Map<WalletCurrencyEntity>(walletCurrencyModel);

        await dbRepository.Update(walletCurrencyEntity);
        await dbRepository.SaveChangesAsync();
    }

    public async Task DeleteWalletCurrency(Guid walletCurrencyId)
    {
        await dbRepository.Delete<WalletCurrencyEntity>(walletCurrencyId);
        await dbRepository.SaveChangesAsync();
    }
}