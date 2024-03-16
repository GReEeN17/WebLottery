using System.Text.Json;
using AutoMapper;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.Services;

public class WalletCurrencyService : IWalletCurrencyService
{
    private readonly IDbRepository _dbRepository;
    private readonly IMapper _mapper;

    public WalletCurrencyService(IDbRepository dbRepository, IMapper mapper)
    {
        _dbRepository = dbRepository;
        _mapper = mapper;
    }
    
    public async Task<string> CreateWalletCurrency(WalletCurrencyModel walletCurrencyModel)
    {
        var walletCurrencyEntity = _mapper.Map<WalletCurrencyEntity>(walletCurrencyModel);
        
        var result = await _dbRepository.Add(walletCurrencyEntity);
        await _dbRepository.SaveChangesAsync();

        return JsonSerializer.Serialize(result);
    }

    public string GetWalletCurrency(int walletCurrencyId)
    {
        var walletCurrencyEntity = _dbRepository.Get<WalletCurrencyEntity>().FirstOrDefault(x => x.Id == walletCurrencyId);
        var walletCurrencyModel = _mapper.Map<WalletCurrencyModel>(walletCurrencyEntity);

        return JsonSerializer.Serialize(walletCurrencyModel);
    }

    public async Task UpdateWalletCurrency(WalletCurrencyModel walletCurrencyModel)
    {
        var walletCurrencyEntity = _mapper.Map<WalletCurrencyEntity>(walletCurrencyModel);

        await _dbRepository.Update(walletCurrencyEntity);
        await _dbRepository.SaveChangesAsync();
    }

    public async Task DeleteWalletCurrency(int walletCurrencyId)
    {
        await _dbRepository.Delete<WalletCurrencyEntity>(walletCurrencyId);
        await _dbRepository.SaveChangesAsync();
    }
}